using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
   
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool canJump;
    public bool landed = true;
    public ShakeCamera shakeCamera;
    public bool isGettingBored = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) && canJump) || (Input.touchCount > 0 && canJump))
        {
            landed = false;
            canJump = false;
            AudioManager.PlaySound("jump");
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            StartCoroutine(shakeCamera.Shake(.07f, .04f));
        }
        else if (landed && SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount == 0)
            {
                canJump = true;
            }
        }
        else if (landed && SystemInfo.deviceType == DeviceType.Desktop)
        {
            canJump = true;
        }


        if (rb.velocity.y > 0)
        {
            animator.SetBool("isfalling", false);
            animator.SetBool("isjumping", true);
            landed = false;
            canJump = false;
            isGettingBored = false;

        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool("isjumping", false);
            animator.SetBool("isfalling", true);
            landed = false;
            canJump = false;
            isGettingBored = false;
        }
        else if (rb.velocity.y == 0)
        {
            if (!landed)
            {
                AudioManager.PlaySound("land");
                landed = true;
                StartCoroutine(shakeCamera.Shake(.07f, .04f));
                StartCoroutine(Bored());
            }
            animator.SetBool("isfalling", false);
            animator.SetBool("isjumping", false);
            
        }
    }

    private IEnumerator Bored()
    {
        isGettingBored = true;
        yield return new WaitForSecondsRealtime(Random.Range(1, 10f));
        if (!animator.GetBool("isfalling") && !animator.GetBool("isjumping") && isGettingBored)
        {
            animator.SetBool("isBored", true);
            isGettingBored = false;
        }
        
    }
    public void OutOfBored()
    {
        animator.SetBool("isBored", false);
    }

    public void Onlanding()
    {
        animator.SetBool("isfalling", false);
        animator.SetBool("isjumping", false);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Trampoline")
        {
            this.jumpForce = 15f;
        }
        else
        {
            this.jumpForce = 10f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //canJump = false;
    }

}
