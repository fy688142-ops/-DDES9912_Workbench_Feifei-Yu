using UnityEngine;
using System.Collections;

public class GhostVoice : MonoBehaviour
{
    public AudioSource ghostVoice;

    // Sound will play after four seconds
    void Start()
    {
        ghostVoice.Stop();
        StartCoroutine(Voice());
    }

    IEnumerator Voice()
    {
        yield return new WaitForSeconds(4f);

        ghostVoice.Play();
    }
}
