using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject purpleBulb;
    public GameObject redBulb;
    public Light spotLight;

    void Update()
    {
        // If the spotlight is off, show the purple bulb
        if (spotLight.enabled == false)
        {
            redBulb.SetActive(false);
            purpleBulb.SetActive(true);
        }

        // If the spotlight is on, show the red bulb
        if (spotLight.enabled == true)
        {
            redBulb.SetActive(true);
            purpleBulb.SetActive(false);
        }
    }
}
