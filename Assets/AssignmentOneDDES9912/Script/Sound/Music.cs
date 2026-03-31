using UnityEngine;

// Controls audio playback based on gear rotation.
public class Music : MonoBehaviour
{
    // Reference to the driving gear.
    public Gear33ToothSpin previousGear;
    // Audio source for the music box sound.
    public AudioSource lullaby;
    // Last recorded gear angle.
    private float lastValue;

    //Initialize by storing the inital gear's current angle.
    void Start()
    {
        lastValue = previousGear.gearAngle;
    }

    // Checks gear movement each frame and controls audio playback accordingly.
    void Update()
    {
        float newAngle = previousGear.gearAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        // If gear is rotating forward, play music.
        if (delta > 0)
        {
            // Ensure volume is fully on.
            lullaby.volume = 1f;

            // Resume if paused, otherwise start playing.
            if (lullaby.time > 0f)
            {
                lullaby.UnPause();
            }
            else
            {
                lullaby.Play();
            }
        }
        else
        {
            // Gradually fade out volume when not rotating.
            lullaby.volume = Mathf.MoveTowards(lullaby.volume, 0, Time.deltaTime * 5f);

            // Pause audio when volume reaches zero.
            if (lullaby.volume <= 0f && lullaby.isPlaying)
            {
                lullaby.Pause();
            }
        }

        // Store current value for next frame comparison.
        lastValue = newAngle;
    }
}
