using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public AudioSource lullabyAudio;
    public AudioSource doorOpenSound;


    void Start()
    {
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        // Wait until the music starts
        yield return new WaitUntil(() => lullabyAudio.isPlaying);

        // Wait until the music stops
        yield return new WaitUntil(() => !lullabyAudio.isPlaying);

        // Play the door open sound
        doorOpenSound.Play();

        // Open the door
        float time = 0f;
        float duration = 5f;

        Quaternion startRotation = transform.localRotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 100f, 0f);

        while (time < duration)
        {
            time += Time.deltaTime;

            transform.localRotation = Quaternion.Lerp(
                startRotation,
                targetRotation,
                time / duration
            );

            yield return null;
        }

        transform.localRotation = targetRotation;
    }
   
}