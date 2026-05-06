using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;


public class Fire : MonoBehaviour
{
    // Particle system for the flame of different colors
    public ParticleSystem redFire;
    public ParticleSystem blueFire;

    // Audio source for the ignition sound
    public AudioSource ignition;

    // Reference to the MagicCircle script
    public MagicCircle magicCircle;
    
    private float radius;

    void Start()
    {
        // Make sure both flames are off at the beginning
        blueFire.Stop();
        redFire.Stop();
        
        StartCoroutine(igniting());
    }

    // Set the timing for sound playback and flame activation
    IEnumerator igniting()
    {
        yield return new WaitForSeconds(0.2f);
        ignition.Play();
        yield return new WaitForSeconds(0.5f);
        redFire.Play();
        
    }
    // If the magic circle reaches the target radius, the color of the flame will change
    void Update()
    {
        radius = magicCircle.radius;

        if(radius == 0.5f)
        {
            redFire.Stop();
            blueFire.Play();
        }
    }
}
