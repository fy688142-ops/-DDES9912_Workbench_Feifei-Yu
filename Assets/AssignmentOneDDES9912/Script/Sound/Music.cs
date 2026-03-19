using UnityEngine;

public class Music : MonoBehaviour
{
    public Gear33ToothSpin previousGear;
    public AudioSource lullaby;

    private float lastValue;
    void Start()
    {
        lastValue = previousGear.gearAngle;
    }

    void Update()
    {
        float newAngle = previousGear.gearAngle;
        float delta = Mathf.DeltaAngle(lastValue, newAngle);

        if (delta > 0)
        {
            lullaby.volume = 1f;

            if (lullaby.time > 0f)
            {
                lullaby.UnPause();
            }
            else
            {
                lullaby.Play();
            }
        }
        else
        {
            lullaby.volume = Mathf.MoveTowards(lullaby.volume, 0, Time.deltaTime * 5f);

            if (lullaby.volume <= 0f && lullaby.isPlaying)
            {
                lullaby.Pause();
            }
        }

        lastValue = newAngle;
    }
}
