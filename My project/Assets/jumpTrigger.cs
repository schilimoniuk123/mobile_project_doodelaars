using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
   
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool canJump;

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
            Debug.Log("kanker");
            animator.SetBool("isjumping", true);
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }
    public void Onlanding()
    {
        animator.SetBool("isjumping", false);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

}