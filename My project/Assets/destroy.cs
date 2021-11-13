using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject doodler;
    public GameObject platformprefab;
    private GameObject myPlat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            Destroy(collision.gameObject);
            myPlat = (GameObject)Instantiate(platformprefab, new Vector2(Random.Range(-2.3f, 2.3f), doodler.transform.position.y + (5 + Random.Range(0.1f, 1.8f))), Quaternion.identity);
            //collision.gameObject.transform.position = new Vector2(Random.Range(-2f, 2f), doodler.transform.position.y + (6 + Random.Range(0.4f, 1f)));

        }
        else if (collision.gameObject.name.StartsWith("Doodler"))
        {
            Destroy(collision.gameObject);
        }




        
        //Destroy(collision.gameObject);
    }
}
