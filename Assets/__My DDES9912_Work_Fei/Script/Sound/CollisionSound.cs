using UnityEngine;
using UnityEngine.Audio;

public class CollisionSound : MonoBehaviour
{
    public AudioSource windUp;
    public WinderRootSpin winder;

    private bool isTouching = false;
    private float lastValue;
    void Start()
    {
        lastValue = winder.currentAngle;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpringSystem")
        {
            isTouching = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "SpringSystem" )
        {
            isTouching = false;
            
        }
    }
    void Update()
    {
        float newAngle = winder.currentAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        if (delta > 0)
        {
            windUp.volume = 1f;

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
            windUp.Pause();
        }

            lastValue = newAngle;
    }

}
