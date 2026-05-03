using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject yellowBulb;
    public GameObject redBulb;
    public Light spotLight;

    // Update is called once per frame
    void Update()
    {
        if(spotLight.enabled == false)
        {
            redBulb.SetActive(false);
            yellowBulb.SetActive(true);
        }

        if (spotLight.enabled == true)
        {
            redBulb.SetActive(true);
            yellowBulb.SetActive(false);
        }
    }
}
