using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, arrowSound, birdSound, waterSound;
    static AudioSource audioSrc;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        arrowSound = Resources.Load<AudioClip>("arrowSound");
        birdSound = Resources.Load<AudioClip>("birdSound");
        waterSound = Resources.Load<AudioClip>("waterSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "arrow":
                audioSrc.PlayOneShot(arrowSound);
                break;
            case "bird":
                audioSrc.PlayOneShot(birdSound);
                break;
            case "water":
                audioSrc.PlayOneShot(waterSound);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
