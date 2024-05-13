using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tocado tiene el tag 'Player'
        if (other.CompareTag("Player"))
        {
            // Obtener el componente PlayerHealth del jugador y llamar al método TakeDamage
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.LoseLife();
            }
        }
    }
}
