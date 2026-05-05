using TMPro;
using UnityEngine;

public class WindingEnergy : MonoBehaviour
{
    public WinderRootSpin winderRootSpin;
    public TMP_Text windingEnergy;

    private float startAngle = 0f;
    private float endAngle = 200f;

    private float previousAngle;

    private void Start()
    {
        previousAngle = winderRootSpin.currentAngle;

    }


    private void Update()
    {

        float currentAngle = winderRootSpin.currentAngle;

        if (currentAngle > previousAngle)
        {
            float progress = Mathf.InverseLerp(startAngle, endAngle, currentAngle);
            int percent = Mathf.RoundToInt(progress * 100f);

            windingEnergy.text = $"Winding Energy: {percent}%";
        }

        previousAngle = currentAngle;
    }
}
