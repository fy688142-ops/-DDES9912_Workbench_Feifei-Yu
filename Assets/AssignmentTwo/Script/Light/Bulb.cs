using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject purpleBulb;
    public GameObject redBulb;
    public Light spotLight;

    // Update is called once per frame
    void Update()
    {
        if(spotLight.enabled == false)
        {
            redBulb.SetActive(false);
            purpleBulb.SetActive(true);
        }

        if (spotLight.enabled == true)
        {
            redBulb.SetActive(true);
            purpleBulb.SetActive(false);
        }
    }
}
