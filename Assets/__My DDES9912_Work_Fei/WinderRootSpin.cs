using UnityEngine;

public class WinderRootSpin : MonoBehaviour
{
    public float rotateSpeed = 1000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        { 
            float mousemove = Input.GetAxis("Mouse X");

            transform.Rotate(mousemove*rotateSpeed*Time.deltaTime,0, 0);
        }
    }
}
