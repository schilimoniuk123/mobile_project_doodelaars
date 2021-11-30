using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour
{
    public GameObject doodler;
    public GameObject platformprefab;
    private GameObject myPlat;
    // Start is called before the first frame update

    public GameObject retryButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            Destroy(collision.gameObject);
            myPlat = (GameObject)Instantiate(platformprefab, new Vector2(Random.Range(-2.3f, 2.3f), doodler.transform.position.y + (5 + Random.Range(0.1f, 1.8f))), Quaternion.identity);
        }
        else if (collision.gameObject.name.StartsWith("Doodler"))
        {

            Handheld.Vibrate();

            AudioManager.PlaySound("falldown");
            Destroy(collision.gameObject);

            StartCoroutine(RemoveAfterSeconds());
        }

    }

    IEnumerator RemoveAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        retryButton.hideFlags = HideFlags.HideInHierarchy;
        retryButton.SetActive(true);
    }

}
