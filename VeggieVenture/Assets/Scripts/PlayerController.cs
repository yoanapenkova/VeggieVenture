using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables de movimiento
    public float speed = 5f;
    public float runSpeedMultiplier = 2f; // Multiplicador de velocidad al correr
    public float jumpForce = 8f;
    public float wallJumpForce = 10f; // Fuerza de salto sobre paredes
    public float gravity = 20f; // Valor de gravedad

    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool canDoubleJump = true; // Variable para rastrear si el jugador puede hacer un doble salto
    private bool canWallJump = true; // Variable para rastrear si el jugador puede hacer un salto sobre paredes
    private Vector3 wallJumpNormal;
    private Transform lastWallJumpedFrom; // Última pared sobre la que el jugador ha saltado

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener entrada de teclado para mover al personaje
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movimiento horizontal y vertical siempre está disponible
        moveDirection = new Vector3(-horizontalInput * speed, moveDirection.y, -verticalInput * speed);
        moveDirection = transform.TransformDirection(moveDirection);

        if (characterController.isGrounded)
        {
            canDoubleJump = true;
            canWallJump = false;

            //moveDirection = new Vector3(-horizontalInput, 0f, -verticalInput);
            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            if(Input.GetButtonDown("Jump"))
            {
                // Salto sobre paredes
                if (canWallJump)
                {
                    Debug.Log("VA A SALTAR SOBRE PARED " + lastWallJumpedFrom);
                    //Debug.Log(lastWallJumpedFrom);
                    /*
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
                    {
                        Debug.Log(hit.collider);
                        if (hit.collider.CompareTag("Wall") && hit.transform != lastWallJumpedFrom)
                        {
                            Debug.Log("SALTO");
                            Debug.Log("HEY" + characterController.isGrounded);
                            moveDirection = hit.normal * wallJumpForce;
                            moveDirection.y = jumpForce;
                            lastWallJumpedFrom = hit.transform;
                            // canWallJump = false; // Desactivar la posibilidad de salto sobre paredes hasta que el jugador toque el suelo nuevamente
                        }
                    }
                    */
                    
                    moveDirection = wallJumpNormal * wallJumpForce;
                    moveDirection.y = jumpForce;
                }

                // Doble salto
                if (canDoubleJump)
                {
                    moveDirection.y = jumpForce;
                    canDoubleJump = false; // Desactivar la posibilidad de doble salto hasta que el jugador toque el suelo nuevamente
                }
            }
            

            // Aplicar gravedad incluso durante el salto
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover al personaje
        characterController.Move(moveDirection * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (!characterController.isGrounded && hit.transform.CompareTag($"Wall")) 
        {
            
            Debug.DrawRay(hit.point,hit.normal, Color.blue);
        
            /*
            if (hit.transform != lastWallJumpedFrom){
                Debug.Log("puede saltar");
                canWallJump = true;
                wallJumpNormal = hit.normal;
                lastWallJumpedFrom = hit.transform;
                isJumping = true;
            } else {
                //Debug.Log("NO puede saltar");
                canWallJump = false;
            }*/
            if( hit.transform != lastWallJumpedFrom){
                canWallJump = true;
                wallJumpNormal = hit.normal;
                lastWallJumpedFrom = hit.transform;
            } else {
                canWallJump = false;
                lastWallJumpedFrom = null;
            }
            
        }
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        // Restablecer la posibilidad de salto sobre paredes cuando el jugador toca el suelo
        if (characterController.isGrounded)
        {
            canWallJump = true;
        }
    }
    */
}
