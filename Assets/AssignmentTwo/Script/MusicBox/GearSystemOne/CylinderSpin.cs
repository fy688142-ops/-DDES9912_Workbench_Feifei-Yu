using UnityEngine;

// Controls the rotation of the cylinder based on the previous gear's rotation.

public class GearSystemOneCylinderSpin : MonoBehaviour
{
    // Reference to the previous gear driving this one.
    public Gear33ToothSpin previousGear;
    // Multiplier controlling rotation speed relative to previous gear.
    public float gearRatio = 2.75f;
    // Accumulated rotation angle of this gear.
    public float gearAngle = 0f;
    // Last recorded angle of the previous gear.
    private float lastValue;
    // Determines whether this gear should rotate this frame.
    private bool gearSpin = false;

    //Initialize by storing the previous gear's current angle.
    void Start()
    {
        lastValue = previousGear.gearAngle;
    }

    // Check the previous gear rotation every frame and rotate the gear accordingly. 
    void Update()
    {
        //Updates rotation by comparing the previous gear's angle over time.
        float newAngle = previousGear.gearAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        //Rotates only when the angle change is in the correct direction.
        if (delta > 0)
        {
            gearSpin = true;
        }
        else
        {
            gearSpin = false;
        }


        // Apply rotation if valid.
        if (gearSpin)
        {
            transform.Rotate(0f, 0f, -delta * gearRatio);
            gearAngle = gearAngle - delta * gearRatio;
        }

        // Store current value for next frame comparison.
        lastValue = newAngle;
    }
}
