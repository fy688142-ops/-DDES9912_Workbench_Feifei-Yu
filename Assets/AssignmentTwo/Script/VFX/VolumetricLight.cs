using UnityEngine;
using System.Collections;
public class VolumetricLight : MonoBehaviour
{
    public ParticleSystemRenderer volumetricLight;
    public Light spotLight;

    void Update()
    {
        if (spotLight.enabled == false)
        {
            volumetricLight.enabled = false;
        }

        if (spotLight.enabled == true)
        {
            volumetricLight.enabled = true;
        }
    }
}
