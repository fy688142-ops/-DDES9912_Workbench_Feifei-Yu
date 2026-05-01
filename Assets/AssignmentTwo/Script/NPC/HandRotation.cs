using UnityEngine;
using System.Collections;

public class HandRotation : MonoBehaviour
{
    public AudioSource ghostVoice;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        StartCoroutine(VoiceThenMoveHand());
    }

    IEnumerator VoiceThenMoveHand()
    {
        // Play voice
        ghostVoice.Play();

        // Wait until voice ends
        yield return new WaitForSeconds(ghostVoice.clip.length);

        // Rotate hand
        float time = 0f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float x = Mathf.Lerp(0f, -105.444f, time / duration);
            transform.localRotation = Quaternion.Euler(x, 0f, 0f);

            yield return null;
        }

        transform.localRotation = Quaternion.Euler(-105.444f, 0f, 0f);

        // Wait 2 seconds
        yield return new WaitForSeconds(2.5f);

        // Lower hand
        time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float x = Mathf.Lerp(-105.444f, 0f, time / duration);
            transform.localRotation = Quaternion.Euler(x, 0f, 0f);

            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
