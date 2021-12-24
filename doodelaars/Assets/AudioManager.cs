using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioClip falldownSound, jumpUpSound, landSound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        falldownSound = Resources.Load<AudioClip>("Doodelaar_Fall_Down");
        jumpUpSound = Resources.Load<AudioClip>("Doodelaar_Jump");
        landSound = Resources.Load<AudioClip>("Doodelaar_Land");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audiosrc.PlayOneShot(jumpUpSound);
                break;
            case "land":
                audiosrc.PlayOneShot(landSound);
                break;
            case "falldown":
                audiosrc.PlayOneShot(falldownSound);
                break;
            default:
                break;
        }
    }

}
