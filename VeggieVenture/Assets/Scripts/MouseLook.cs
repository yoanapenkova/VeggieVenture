using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 200f; // Sensibilidad del movimiento del ratón

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

    }
}
