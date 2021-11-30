using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private float moveX;

    Vector3 characterScale;
    private float topScore = 0.0f;
    public Text scoreText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
                
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.acceleration.x * moveSpeed + Input.GetAxis("Horizontal") * moveSpeed;
        //moveX = Input.GetAxis("Horizontal") * moveSpeed;


        Vector3 characterScale = transform.localScale;
        if ((Input.acceleration.x * moveSpeed > 0.1f) || (Input.GetAxis("Horizontal") > 0) )
        {
            //face rechts
            characterScale.x = 3.5f;
            transform.localScale = characterScale;
        }
        else if ((Input.acceleration.x * moveSpeed < -0.1f) || (Input.GetAxis("Horizontal") < 0))
        {
            //face links
            characterScale.x = -3.5f;
            transform.localScale = characterScale;
        }
        

        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;

        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();



    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
