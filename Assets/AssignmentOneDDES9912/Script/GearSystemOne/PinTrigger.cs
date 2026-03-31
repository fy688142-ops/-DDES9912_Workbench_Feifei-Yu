using UnityEngine;
using System.Collections;

// Handles interaction between the music box cylinder pins and the tine.
public class pinTrigger : MonoBehaviour
{
    // Rotation applied to the tine when triggered.
    private float hitAngle = 0.6f;

    // Rotates the tine downward if the correct object is detected.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tine"))
        {
            other.transform.Rotate(-hitAngle, 0f, 0f);
        }
    }

    // Resets the tine back to its original position if not touching.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tine"))
        {
            other.transform.Rotate(hitAngle, 0f, 0f);
        }
    }
}

