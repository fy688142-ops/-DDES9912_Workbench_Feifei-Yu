using UnityEngine;

public class GhostSway : MonoBehaviour
{
    // Start position
    private Vector3 startPosition;

    // Half circle width
    public float radiusX = 0.5f;

    // Half circle height
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
        // Loop angle from 0 to PI
        float angle = Mathf.PingPong(Time.time * speed, Mathf.PI);

        // Half-circle movement
        float x = -(1f - Mathf.Cos(angle)) * radiusX;
        float y = -Mathf.Sin(angle) * radiusY;

        transform.position = startPosition + new Vector3(x, y, 0f);
    }
}
