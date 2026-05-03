using UnityEngine;
using System.Collections;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public Light spotLight;
    public AudioSource windUp;
    public AudioSource lightSound;
    void Start()
    {
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        // Hide light at start
        spotLight.enabled = false;

        // Wait 7 seconds
        yield return new WaitForSeconds(11.6f);

        lightSound.Play();

        yield return new WaitForSeconds(0.5f);
        // Show light
        spotLight.enabled = true;

        // Wait until music box starts playing
        yield return new WaitUntil(() => windUp.isPlaying);
        yield return new WaitUntil(() => !windUp.isPlaying);

        // Hide light again
        spotLight.enabled = false;
    }
}
