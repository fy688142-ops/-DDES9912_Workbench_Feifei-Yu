using UnityEngine;

public class Gear33ToothSpin : MonoBehaviour
{
    public bool touchingSpring = false;
    public WinderRootSpin winder; 
    public float gearRatio = 1f;
    public float gearAngle = 0f;

    private float lastValue;
    private bool gearSpin;
    
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


        if(gearSpin)
        {
            transform.Rotate(0f, 0f, -delta * gearRatio);
            gearAngle = gearAngle - delta * gearRatio;
        }
        
        lastValue = newAngle;
    }
}
