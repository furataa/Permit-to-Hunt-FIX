using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform playerBody;
    public Transform weaponHolder;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float mouseX;
        float mouseY;

        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x * sensitivity * Time.deltaTime;
            mouseY = Mouse.current.delta.ReadValue().y * sensitivity * Time.deltaTime;
        }
        else
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        }

        // ROTASI X (atas bawah)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Kamera rotasi X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // PlayerBody ikut rotasi X dan Y
        playerBody.localRotation = Quaternion.Euler(
            xRotation, 
            playerBody.localRotation.eulerAngles.y + mouseX,
            0f
        );

        // Senjata ikut kamera
        if (weaponHolder != null)
        {
            weaponHolder.position = transform.position;
            weaponHolder.rotation = transform.rotation;
        }
    }
}
