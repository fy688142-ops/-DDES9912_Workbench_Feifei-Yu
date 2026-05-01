using UnityEngine;
using UnityEngine.Audio;

// Plays and controls the winding sound based on the rotation of the winder.
public class CollisionSound : MonoBehaviour
{
    // Audio source for winding sound.
    public AudioSource windUp;
    // Reference to the winder controlling rotation.
    public WinderRootSpin winder;
    // Last recorded angle of the winder.
    private float lastValue;

    //Initialize by storing the winder's current angle.
    void Start()
    {
        lastValue = winder.currentAngle;
    }

    // Checks winder rotation each frame and controls sound playback.
    void Update()
    {
        // If rotating forward, play sound.
        float newAngle = winder.currentAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        if (delta > 0)
        {
            windUp.volume = 1f;

            // Resume if paused, otherwise start playing.
            if (windUp.time > 0f)
            {
                windUp.UnPause();
            }
            else
            {
                windUp.Play();
            }
        }
        else
        {
            // Pause sound when not rotating
            windUp.Pause();
        }

        // Store current value for next frame comparison.    
        lastValue = newAngle;
    }

}
