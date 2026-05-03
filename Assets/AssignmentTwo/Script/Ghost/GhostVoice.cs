using UnityEngine;
using System.Collections;

public class GhostVoice : MonoBehaviour
{
    public AudioSource ghostVoice;
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
