using UnityEngine;
using TMPro;
using System.Collections;

public class DoorStatus : MonoBehaviour
{
    public AudioSource doorOpenSound;
    public TMP_Text doorStatus;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorStatus.text = "Door Status: Locked";
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitUntil(() => doorOpenSound.isPlaying);

        doorStatus.text = "Door Status: Opening";

        yield return new WaitUntil(() => !doorOpenSound.isPlaying);

        doorStatus.text = "Door Status: Open";
    }

} 
    

