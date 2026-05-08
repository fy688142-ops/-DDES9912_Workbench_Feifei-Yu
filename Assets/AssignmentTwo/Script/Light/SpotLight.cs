using UnityEngine;
using System.Collections;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public Light spotLight;
    public AudioSource musicBox;
    public AudioSource lightSound;
    void Start()
    {
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        // Hide light at start
        spotLight.enabled = false;

        // Wait some seconds
        yield return new WaitForSeconds(11.6f);

        lightSound.Play();

        yield return new WaitForSeconds(0.5f);
        // Show light
        spotLight.enabled = true;

        // Wait until music box starts playing
        yield return new WaitUntil(() => musicBox.isPlaying);

        // Hide light again
        spotLight.enabled = false;
    }
}
