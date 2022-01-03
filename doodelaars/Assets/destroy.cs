using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour
{
    public GameObject doodler;
    public GameObject platformprefab;
    private GameObject myPlat;
    public GameObject pauseButton;
    public ShakeCamera shakeCamera;
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
            AudioManager.PlaySound("falldown");
            Destroy(collision.gameObject, 1f);
            retryButton.SetActive(true);
            StartCoroutine(HitGround());
            StartCoroutine(RemoveAfterSeconds());
        }

    }

    IEnumerator HitGround()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        Handheld.Vibrate();
        StartCoroutine(shakeCamera.Shake(.5f, .1f));
    }
    IEnumerator RemoveAfterSeconds()
    {
        pauseButton.SetActive(false);
        
        yield return new WaitForSecondsRealtime(2);
        retryButton.hideFlags = HideFlags.HideInHierarchy;
        retryButton.SetActive(true);
    }

}
