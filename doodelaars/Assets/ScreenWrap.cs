using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenWrap : MonoBehaviour
{

	public Camera mainCam;
	public BoxCollider2D LeftWall;
	public BoxCollider2D RigthWall;
    private Boolean entertimeout = true;


    void Start()
    {
        //Camera camera = Camera.main;
        float halfHeight = mainCam.orthographicSize;
        float halfWidth = mainCam.aspect * halfHeight;

        var horizontalMin = -halfWidth - (RigthWall.size.x / 2 + RigthWall.size.x / 4);
        var horizontalMax = halfWidth + (LeftWall.size.x / 2 + RigthWall.size.x / 4);


        RigthWall.transform.position = new Vector2(horizontalMax, 0f);
        LeftWall.transform.position = new Vector2(horizontalMin, 0f);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "RightWall" && entertimeout)
        {
            entertimeout = false;
            float x = transform.position.x;

            transform.position = new Vector3(x - x - x + 0.2f, transform.position.y, transform.position.z);
            StartCoroutine(enumtimeout());
        }


        if (other.gameObject.tag == "LeftWall" && entertimeout)
        {
            entertimeout = false;
            float y = transform.position.x;

            transform.position = new Vector3(y - y - y - 0.2f, transform.position.y, transform.position.z);
            StartCoroutine(enumtimeout());
        }
    }

    IEnumerator enumtimeout()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        entertimeout = true;
    }

}
