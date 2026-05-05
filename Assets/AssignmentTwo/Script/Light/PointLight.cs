using UnityEngine;

public class PointLight : MonoBehaviour
{
    public Light spotLight;
    public Light pointLight;

    void Update()
    {
        if (spotLight.enabled == false)
        {
            pointLight.enabled = true;
        }

        if (spotLight.enabled == true)
        {
            pointLight.enabled = false;
        }

    }
}
