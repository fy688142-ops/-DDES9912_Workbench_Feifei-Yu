using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Object material
    private Material mat;

    // Emission color
    private Color emissionColor;

    // Min brightness
    public float lowIntensity = 0.4f;

    // Max brightness
    public float highIntensity = 10f;

    // Blink speed
    public float speed = 1f;

    void Start()
    {
        // Get material
        mat = GetComponent<Renderer>().material;

        // Enable emission
        mat.EnableKeyword("_EMISSION");

        // Set color
        emissionColor = Color.white;
    }

    void Update()
    {
        // Converts the value to a range between 0 and 1
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;

        // Smoothly interpolate between lowIntensity and highIntensity
        float intensity = Mathf.Lerp(lowIntensity, highIntensity, t);

        // Apply the emission color with the calculated intensity
        mat.SetColor("_EmissionColor", emissionColor * intensity);
    }
}