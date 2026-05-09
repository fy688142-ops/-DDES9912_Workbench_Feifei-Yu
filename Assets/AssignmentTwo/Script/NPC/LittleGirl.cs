using UnityEngine;
using System.Collections;

public class LittleGirl : MonoBehaviour
{
    public AudioSource ghostVoice;

    void Start()
    {
        StartCoroutine(MoveHand());
    }

    IEnumerator MoveHand()
    {
        // Wait until the ghost voice finishes playing
        yield return new WaitUntil(() => ghostVoice.isPlaying);

        yield return new WaitUntil(() => !ghostVoice.isPlaying);

        yield return new WaitForSeconds(2f);

        // Raise the hand
        float time = 0f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float x = Mathf.Lerp(0f, -105.444f, time / duration);
            transform.localRotation = Quaternion.Euler(x, 0f, 0f);

            yield return null;
        }


        // Keep the hand raised for a short time
        yield return new WaitForSeconds(2.5f);

        // Lower the hand back down
        time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float x = Mathf.Lerp(-105.444f, 0f, time / duration);
            transform.localRotation = Quaternion.Euler(x, 0f, 0f);

            yield return null;
        }
    }
}
