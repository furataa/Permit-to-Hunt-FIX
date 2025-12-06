using UnityEngine;
using UnityEngine.InputSystem; // Input System baru

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX;
        float mouseY;

        // Input System baru
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x * sensitivity * Time.deltaTime;
            mouseY = Mouse.current.delta.ReadValue().y * sensitivity * Time.deltaTime;
        }
        else
        {
            // Input lama
            mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

