using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool canJump;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("kanker");
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetMouseButtonDown(0) && canJump) || (Input.touchCount > 0 && canJump))
        {
            Debug.Log("kurwa");
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            canJump = false;
        }
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
