using TMPro;
using UnityEngine;

public class WindingEnergy : MonoBehaviour
{
    // Reference to the winderRootSpin script
    public WinderRootSpin winderRootSpin;
    
    public TMP_Text windingEnergy;

    private float startAngle = 0f;
    
    private float endAngle = 200f;

    private float previousAngle;

    private void Start()
    {
        // Get data
        previousAngle = winderRootSpin.currentAngle;
    }


    private void Update()
    {
        // Get current angle of the winder
        float currentAngle = winderRootSpin.currentAngle;

        // Update when the angle is increasing and convert progress to percentage
        if (currentAngle > previousAngle)
        {
            float progress = Mathf.InverseLerp(startAngle, endAngle, currentAngle);
            int percent = Mathf.RoundToInt(progress * 100f);

            windingEnergy.text = $"Winding Energy: {percent}%";
        }
        
        // Store current angle for next frame
        previousAngle = currentAngle;
    }
}
