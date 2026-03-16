using UnityEngine;
using UnityEngine.UIElements;

public class WinderRootSpin : MonoBehaviour
{
    public float rotateSpeed = 3f;
    public float returnSpeed = 2f;

    private float currentAngle = 0f;
    private bool returning = false;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.IsChildOf(this.transform))
                {
                    isDragging = true;
                }
            }
        }
        if (Input.GetMouseButton(0) && isDragging)
        {
            float mouseMove = Input.GetAxis("Mouse X");
            returning = false;

            if (Mathf.Abs(mouseMove) > 0.001f)
            {
                float nextAngle = currentAngle + mouseMove * rotateSpeed;

                if (nextAngle >= -180f && nextAngle <= 720f)
                {
                    float rotationDelta = mouseMove * rotateSpeed;
                     
                    transform.Rotate(rotationDelta, 0f, 0f);
                    currentAngle = nextAngle;
                }
            }
        }

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

        if (returning)
        {
            float previousAngle = currentAngle;

            currentAngle = Mathf.MoveTowards(currentAngle, 0f, returnSpeed * Time.deltaTime);

            float deltaBack = currentAngle - previousAngle;
            transform.Rotate(deltaBack, 0f, 0f);

            if (Mathf.Approximately(currentAngle, 0f))
            {
                currentAngle = 0f;
                returning = false;
            }
        }
    }
}

