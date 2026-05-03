using System.ComponentModel;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    // Gear to check
    public Gear38ToothSpin previousGear;

    // Magic circle renderer
    public SpriteRenderer magicCircleRenderer;

    public GameObject magicCircle;
    public float rotateSpeed = 30f;


    // Max radius
    public float maxRadius = 0.5f;

    // Grow speed
    public float speed = 0.05f;

    private Material mat;
    private float radius = 0f;
    private float lastValue;

    private bool gearSpin = true;
    private bool appear = false;
    private bool expand = false;
    private bool soundPlayed = false;
    public AudioSource magicSound;


    void Start()
    {
        mat = magicCircleRenderer.material;

        // Start from invisible
        radius = 0f;
        mat.SetFloat("_Radius", radius);

        // Save initial gear angle
        lastValue = previousGear.gearAngle;

        magicCircle.SetActive(false);

    }
    void Update()
    {
        if (gearSpin == true)
        {
            float newAngle = previousGear.gearAngle;
            float delta = Mathf.DeltaAngle(lastValue, newAngle);


            if (delta < 0f)
            {
                gearSpin = false;
                appear = true;
                expand = true;
            }

            lastValue = newAngle;
        }

        if (appear)
        {
            magicCircle.SetActive(true);
            if (!soundPlayed)
            {
                magicSound.Play();
                soundPlayed = true;
            }
        }

        // If gear is moving
        if (expand)
        {
            radius += speed * Time.deltaTime;
            radius = Mathf.Clamp(radius, 0f, maxRadius);

            mat.SetFloat("_Radius", radius);
            magicCircle.SetActive(true);
            magicCircle.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

            if (radius >= maxRadius)
            {
                expand = false;
            }
        }
    }
}