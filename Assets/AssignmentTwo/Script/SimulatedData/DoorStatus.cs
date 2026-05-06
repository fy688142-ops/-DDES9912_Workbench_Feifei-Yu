using UnityEngine;
using TMPro;
using System.Collections;

public class DoorStatus : MonoBehaviour
{
    public AudioSource doorOpenSound;
    public TMP_Text doorStatus;


    void Start()
    {
        // Set the initial door status to locked
        doorStatus.text = "Door Status: Locked";
        
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        // Update when the door opening sound starts playing
        yield return new WaitUntil(() => doorOpenSound.isPlaying);

        doorStatus.text = "Door Status: Opening";

        // Update when the door opening sound finishes
        yield return new WaitUntil(() => !doorOpenSound.isPlaying);

        doorStatus.text = "Door Status: Open";
    }

} 
    

