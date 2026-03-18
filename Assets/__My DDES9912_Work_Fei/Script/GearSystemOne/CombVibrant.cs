using UnityEngine;
using System.Collections;

public class CombVibrant : MonoBehaviour
{
    private float hitAngle = 0.6f;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tine"))
        {
            other.transform.Rotate(-hitAngle, 0f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tine"))
        {
            other.transform.Rotate(hitAngle, 0f, 0f);
        }
    }
}