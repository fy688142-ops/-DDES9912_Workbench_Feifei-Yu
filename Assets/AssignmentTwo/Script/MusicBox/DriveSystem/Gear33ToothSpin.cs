using UnityEngine;

// Controls the rotation of the 33-tooth gear in gear system one based on the winder rotation.

public class Gear33ToothSpin : MonoBehaviour
{
    // Reference to the winder object that drives this gear.
    public WinderRootSpin winder;
    // Multiplier controlling rotation speed relative to previous gear.
    public float gearRatio = 1f;
    // Accumulated rotation angle of this gear.
    public float gearAngle = 0f;
    // Last recorded angle of the winder.
    private float lastValue;
    // Determines whether this gear should rotate this frame.
    private bool gearSpin;

    //Initialize by storing the winder's current angle.
    void Start()
    {
        lastValue = winder.currentAngle;
    }

    // Check the winder rotation every frame and rotate the gear accordingly.
    void Update()
    {
        //Updates rotation by comparing the winder's angle over time.
        float newAngle = winder.currentAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        //Rotates only when the angle change is in the correct direction.
        if (delta < 0)
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
        
        lastValue = newAngle;
    }
}
