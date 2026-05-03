using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using System.Collections;


public class Fire : MonoBehaviour
{
    public ParticleSystem redFire;
    public ParticleSystem blueFire;

    public AudioSource ignition;

    public MagicCircle magicCircle;
    private float radius;

    void Start()
    {
        blueFire.Stop();
        redFire.Stop();
        StartCoroutine(igniting());
    }

    IEnumerator igniting()
    {
        yield return new WaitForSeconds(0.2f);
        ignition.Play();
        yield return new WaitForSeconds(0.5f);
        redFire.Play();
        
    }
    // Update is called once per frame
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
