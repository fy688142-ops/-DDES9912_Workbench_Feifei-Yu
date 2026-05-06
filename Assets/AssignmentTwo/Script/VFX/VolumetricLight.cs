using UnityEngine;
using System.Collections;
public class VolumetricLight : MonoBehaviour
{
    public ParticleSystemRenderer volumetricLight;
    public Light spotLight;

    void Update()
    {
        // If the spotlight is off, the volumetric light is off
        if (spotLight.enabled == false)
        {
            volumetricLight.enabled = false;
        }

        // If the spotlight is on, the volumetric light is on
        if (spotLight.enabled == true)
        {
            volumetricLight.enabled = true;
        }
    }
}
