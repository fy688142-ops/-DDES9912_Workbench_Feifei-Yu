using UnityEngine;
using System.Collections;

public class LittleBoy : MonoBehaviour
{
    public AudioSource doorOpenSound;
    public AudioSource boyVoice;
    public AudioSource Clapping;

    // Boy animator
    public Animator boyAnimator;

    void Start()
    {
        StartCoroutine(BoyAction());
    }

    IEnumerator BoyAction()
    {
        // Wait until the music starts
        yield return new WaitUntil(() => doorOpenSound.isPlaying);

        // Wait until the music stops
        yield return new WaitUntil(() => !doorOpenSound.isPlaying);

        // Boy turns around
        boyAnimator.SetTrigger("BoyAction");

        // Wait for a while
        yield return new WaitForSeconds(1.5f);

        // Play the voice
        boyVoice.Play();

        // Wait until voice ends
        yield return new WaitForSeconds(boyVoice.clip.length);

        // Boy clapps
        boyAnimator.SetTrigger("Clapping");

        // Play the voice
        Clapping.Play();

    }
}
