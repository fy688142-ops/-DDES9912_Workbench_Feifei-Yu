using UnityEngine;

public class Gear33TeethSpin : MonoBehaviour
{
    public WinderRootSpin winder; 
    public float gearRatio = 1f;
    public float gearAngle = 0f;
    
    private float lastValue;
    private bool gearSpin = false;
    
    void Start()
    {
        lastValue = winder.currentAngle;
    }

    void Update()
    { 
        float newAngle = winder.currentAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        if (delta < 0)
        {
            gearSpin = true;
        }
        else
        {
            gearSpin = false;
        }


        if (winder.currentAngle == 0f)
        {
            gearSpin = false;
            gearAngle = 0f;
        }

        if(gearSpin)
        {
            transform.Rotate(0f, 0f, -delta * gearRatio);
            gearAngle = gearAngle - delta * gearRatio;
        }
        
        lastValue = newAngle;
    }
}
