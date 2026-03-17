using UnityEngine;

public class SpeedControllerSpin : MonoBehaviour
{
    public Gear24TeethSpin previousGear;
    public float gearRatio = 24f;
    public float gearAngle = 0f;

    private float lastValue;
    private bool gearSpin = false;
    void Start()
    {
        lastValue = previousGear.gearAngle;
    }

    void Update()
    {
        float newAngle = previousGear.gearAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        if (delta < 0)
        {
            gearSpin = true;
        }
        else
        {
            gearSpin = false;
        }

        if (previousGear.gearAngle == 0f)
        {
            gearAngle = 0f;
        }

        if (gearSpin)
        {
            transform.Rotate(0f, 0f, delta * gearRatio);
            gearAngle = gearAngle - delta * gearRatio;
        }

        lastValue = newAngle;
    }
}
