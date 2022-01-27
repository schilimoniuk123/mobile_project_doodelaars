using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallex : MonoBehaviour
{
    private float length, startposs;
    public GameObject cam;
    public float parallexEffect;
    void Start()
    {
        startposs = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallexEffect));
        float dist = (cam.transform.position.y * parallexEffect);

        transform.position = new Vector3(transform.position.x, startposs + dist, transform.position.z);
        if (temp > startposs + (length))
        {
            startposs += length;
        }
        else if (temp < startposs - (length))
        {
            startposs -= length;
        }
    }
}
