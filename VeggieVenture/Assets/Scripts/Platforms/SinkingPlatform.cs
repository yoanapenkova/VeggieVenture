using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    public float sinkSpeed = 0.2f; // Velocidad de hundimiento
    public float riseSpeed = 0.5f; // Velocidad de elevación
    public float sinkDistance = 0.5f; // Distancia de hundimiento

    private Vector3 originalPosition; // Posición original de la plataforma
    private bool isSinking = false; // Indica si la plataforma se está hundiendo

    void Start()
    {
        originalPosition = transform.position; // Almacenar la posición original
    }

    void Update()
    {
        if (isSinking)
        {
            // Calcular la nueva posición de la plataforma hundiéndose
            Vector3 targetPosition = originalPosition - Vector3.up * sinkDistance;

            // Mover la plataforma gradualmente hacia la nueva posición
            transform.position = Vector3.Lerp(transform.position, targetPosition, sinkSpeed * Time.deltaTime);
        }
        else
        {
            // Calcular la nueva posición de la plataforma elevándose
            Vector3 targetPosition = originalPosition;

            // Mover la plataforma gradualmente hacia la nueva posición
            transform.position = Vector3.Lerp(transform.position, targetPosition, riseSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si la colisión es con la plataforma
        if (other.CompareTag("Player"))
        {
            isSinking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si la colisión es con la plataforma
        if (other.CompareTag("Player"))
        {
            isSinking = false;
        }
    }
}
