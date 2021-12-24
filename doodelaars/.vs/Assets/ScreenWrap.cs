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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RightWall" && entertimeout)
        {
            entertimeout = false;
            float x = transform.position.x;

            Debug.Log("bal");
            Debug.Log(transform.position.x / 2);
            transform.position = new Vector3(x - x - x + 0.2f, transform.position.y, transform.position.z);
            StartCoroutine(enumtimeout());
        }


        if (other.gameObject.tag == "LeftWall" && entertimeout)
        {
            entertimeout = false;
            float y = transform.position.x;

            Debug.Log("bol");
            Debug.Log(transform.position.x / 2);
            transform.position = new Vector3(y - y - y - 0.2f, transform.position.y, transform.position.z);
            StartCoroutine (enumtimeout());
        }
    }

    IEnumerator enumtimeout()
    {
        Debug.Log(entertimeout);
        yield return new WaitForSeconds(0.01f);
        entertimeout = true;
        Debug.Log(entertimeout);
    }

}
