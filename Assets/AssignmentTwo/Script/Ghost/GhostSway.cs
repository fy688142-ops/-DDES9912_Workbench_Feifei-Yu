using UnityEngine;

public class GhostSway : MonoBehaviour
{
    // Start position
    private Vector3 startPosition;

    // Left-right distance
    public float swayDistance = 0.5f;

    // Up-down distance
    public float floatDistance = 0.2f;

    // Movement speed
    public float speed = 2f;

    void Start()
    {
        // Save original position
        startPosition = transform.position;
    }

    void Update()
    {
        // Make the ghost sway up, down, left, and right
        float x = Mathf.Sin(Time.time * speed) * swayDistance;

        float y = Mathf.Sin(Time.time * speed * 1.5f) * floatDistance;

        transform.position = startPosition + new Vector3(x, y, 0f);
    }
}
