using System.ComponentModel;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    // Used gear to check if the music box is playing music.
    public Gear38ToothSpin previousGear;

    // Magic circle renderer
    public SpriteRenderer magicCircleRenderer;

    // Magic circle GameObject
    public GameObject magicCircle;

    // Rotation speed of the magic circle
    public float rotateSpeed = 30f;

    // Max radius
    public float maxRadius = 0.5f;

    // Expand speed
    public float speed = 0.05f;

    // Material used by the magic circle renderer
    private Material mat;

    // Current radius value of the magic circle
    public float radius = 0f;

    // Stores the previous gear angle for comparison
    private float lastValue;

    private bool gearSpin = true;
    private bool appear = false;
    private bool expand = false;
    private bool soundPlayed = false;
    public AudioSource magicSound;

    void Start()
    {
        // Get the material from the magic circle renderer
        mat = magicCircleRenderer.material;

        // Start from invisible
        radius = 0f;
        mat.SetFloat("_Radius", radius);

        // Save initial gear angle
        lastValue = previousGear.gearAngle;

        // Hide the magic circle object at the beginning
        magicCircle.SetActive(false);

    }
    void Update()
    {
        // Check whether the music box gear has started rotating
        if (gearSpin == true)
        {
            float newAngle = previousGear.gearAngle;
            float delta = Mathf.DeltaAngle(lastValue, newAngle);

            // Allow the magic circle to appear and expand if music box is playing music
            if (delta < 0f)
            {
                gearSpin = false;
                appear = true;
                expand = true;
            }

            // Store current angle for the next frame
            lastValue = newAngle;
        }

        // Show the magic circle and play the magic sound
        if (appear)
        {
            magicCircle.SetActive(true);
            if (!soundPlayed)
            {
                magicSound.Play();
                soundPlayed = true;
            }
        }

        // Expand and rotate the magic circle
        if (expand)
        {
            radius += speed * Time.deltaTime;
            radius = Mathf.Clamp(radius, 0f, maxRadius);

            mat.SetFloat("_Radius", radius);
            magicCircle.SetActive(true);
            magicCircle.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

            // Stop expanding when the maximum radius is reached
            if (radius >= maxRadius)
            {
                expand = false;
               
            }
        }
    }
}