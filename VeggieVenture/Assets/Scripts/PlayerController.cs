using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables de movimiento
    public float speed = 5f;
    public float runSpeedMultiplier = 2f; // Multiplicador de velocidad al correr
    public float jumpForce = 8f;
    public float gravity = 20f; // Valor de gravedad

    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool canDoubleJump = true; // Variable para rastrear si el jugador puede hacer un doble salto

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener entrada de teclado para mover al personaje
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            // Permitir un doble salto
            canDoubleJump = true;

            moveDirection = new Vector3(-horizontalInput, 0f, -verticalInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            // Doble salto
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                canDoubleJump = false; // Desactivar la posibilidad de doble salto hasta que el jugador toque el suelo nuevamente
            }

            // Aplicar gravedad incluso durante el salto
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover al personaje
        characterController.Move(moveDirection * Time.deltaTime);

    }
}
