using TMPro;
using UnityEngine;

public class MusicProgress : MonoBehaviour
{
    public WinderRootSpin winderRootSpin;
    public TMP_Text musicProgrss;

    private float startAngle = 200f;
    private float endAngle = 0f;

    private float previousAngle;

    private void Start()
    {
        previousAngle = winderRootSpin.currentAngle;
   
    }


    private void Update()
    {

        float currentAngle = winderRootSpin.currentAngle;

        if (currentAngle < previousAngle)
        {
            float progress = Mathf.InverseLerp(startAngle, endAngle, currentAngle);
            int percent = Mathf.RoundToInt(progress * 100f);

            musicProgrss.text = $"Music Progress: {percent}%";
        }

        previousAngle = currentAngle;
    }
}
