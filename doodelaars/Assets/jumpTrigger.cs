using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
   
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool canJump;
    public bool landed = true;

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
            animator.SetBool("isjumping", true);
            landed = false;
        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool("isfalling", true);
            landed = false;
        }
        else if (rb.velocity.y == 0)
        {
            if (!landed)
            {
                AudioManager.PlaySound("land");
                landed = true;
                //canJump = true;
            }
            animator.SetBool("isfalling", false);
            animator.SetBool("isjumping", false);
        }

        
    }

    public void Onlanding()
    {
        animator.SetBool("isjumping", false);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        //canJump = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //canJump = false;
    }

}
