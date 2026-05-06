using UnityEngine;

public class GhostSway : MonoBehaviour
{
    // Start position
    private Vector3 startPosition;

    // Width
    public float radiusX = 0.5f;

    // Height
    public float radiusY = 0.3f;

    // Movement speed
    public float speed = 1f;

    void Start()
    {
        // Save original position
        startPosition = transform.position;
    }

    void Update()
    {
        // Creates a repeating angle value between 0 and PI over time
        float angle = Mathf.PingPong(Time.time * speed, Mathf.PI);

        // Calculate the X and Y position based on movement
        float x = -(1f - Mathf.Cos(angle)) * radiusX;
        float y = -Mathf.Sin(angle) * radiusY;

        // Update the object's position
        transform.position = startPosition + new Vector3(x, y, 0f);
    }
}
