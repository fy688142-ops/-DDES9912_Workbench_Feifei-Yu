using UnityEngine;
using UnityEngine.UIElements;

// Controls the rotation of the music box winder.
// Allows the player to drag with the mouse to rotate,
// and automatically returns to the initial position when released.
public class WinderRootSpin : MonoBehaviour
{
    // Speed of rotation while dragging.
    public float rotateSpeed = 2f;
    // Speed of returning to original position.
    public float returnSpeed = 15f;
    // Current rotation angle of the winder.
    public float currentAngle = 0f;
    // Whether the winder is currently returning to start.
    private bool returning = false;
    // Whether the winder is currently returning to start.
    private bool isDragging = false;


    void Update()
    {
        // Detect mouse click and check if the winder is selected.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the clicked object belongs to this winder.
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.IsChildOf(this.transform))
                {
                    isDragging = true;
                }
            }
        }
        // Handle dragging rotation.
        if (Input.GetMouseButton(0) && isDragging)
        {
            float mouseMove = Input.GetAxis("Mouse X");
            returning = false;

            // Only rotate if there is meaningful mouse movement.
            if (Mathf.Abs(mouseMove) > 0.001f)
            {
                float nextAngle = currentAngle + mouseMove * rotateSpeed;

                // Limit rotation range.
                if (nextAngle >= -180f && nextAngle <= 720f)
                {
                    float rotationDelta = mouseMove * rotateSpeed;
                     
                    transform.Rotate(rotationDelta, 0f, 0f);
                    currentAngle = nextAngle;
                }
            }
        }

        // Stop dragging and start return motion if needed.
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (currentAngle > 0)
            {
                returning = true;
            }
            else
            {
                currentAngle = 0f;
                returning = false;
            }
        }
        // Smoothly return to original position.
        if (returning)
        {
            float previousAngle = currentAngle;

            currentAngle = Mathf.MoveTowards(currentAngle, 0f, returnSpeed * Time.deltaTime);

            float deltaBack = currentAngle - previousAngle;
            transform.Rotate(deltaBack, 0f, 0f);

            // Stop returning when fully reset
            if (Mathf.Approximately(currentAngle, 0f))
            {
                currentAngle = 0f;
                returning = false;
            }
        }
    }
}

