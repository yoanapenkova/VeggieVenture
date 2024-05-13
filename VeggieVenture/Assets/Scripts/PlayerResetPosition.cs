using UnityEngine;

public class PlayerResetPosition : MonoBehaviour
{
    private Vector3 initialPosition; // Posición inicial del jugador

    void Start()
    {
        // Almacenar la posición inicial del jugador
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador ha colisionado con el suelo
        if (other.CompareTag("Ground"))
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            Debug.Log(playerHealth);
            if (playerHealth != null && playerHealth.canTakeDamage)
            {
                playerHealth.LoseLife();
            }

            CharacterController controller = GetComponent<CharacterController>();
            controller.enabled = false; // Desactiva el CharacterController temporalmente para mover el transform
            transform.position = initialPosition;
            controller.enabled = true; // Vuelve a activar el CharacterController
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto tocado tiene el tag 'Player'
        if (other.CompareTag("Ground"))
        {
            // Obtener el componente PlayerHealth del jugador y llamar al método TakeDamage
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.EnableDamage();
            }
        }
    }
}
