using System.Collections;
using UnityEngine;

public class OrangeLauncher : MonoBehaviour
{
    public GameObject orangePrefab;
    public Transform launchPoint;
    public float minLaunchInterval = 1f;
    public float maxLaunchInterval = 3f;
    public float launchForce = 10f;
    public float rotationSpeed = 50f; // Velocidad de rotación de la naranja
    public Transform player; // Referencia al transform del jugador
    public float orangeLifetime = 5f; // Tiempo de vida de las naranjas
    private bool calledToStart = false;


    void Start()
    {
        // Desactivar el componente al inicio
        enabled = false;

        launchPoint.position += Vector3.up * 0.05f;
    }

    void Update()
    {
        if (calledToStart){
            StartCoroutine(LaunchOranges());
            calledToStart = false;
        }
        
    }

    // Método para lanzar naranjas periódicamente
    IEnumerator LaunchOranges()
    {
        while (enabled)
        {
            // Calcular el intervalo de lanzamiento aleatorio entre min y max
            float interval = Random.Range(minLaunchInterval, maxLaunchInterval);

            // Crear una instancia de la naranja en la posición del spawn point
            GameObject orange = Instantiate(orangePrefab, transform.position, Quaternion.identity);

            // Obtener la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Obtener el componente Rigidbody de la naranja y aplicarle una fuerza en la dirección del jugador
            Rigidbody rb = orange.GetComponent<Rigidbody>();
            rb.AddForce(direction * launchForce, ForceMode.Impulse);

            // Obtener el componente Rigidbody de la naranja y aplicarle una rotación constante en su eje Z
            rb.angularVelocity = new Vector3(0f, 0f, rotationSpeed);

            // Destruir la naranja después de un cierto tiempo
            Destroy(orange, orangeLifetime);

            // Esperar el intervalo de lanzamiento antes de lanzar la próxima naranja
            yield return new WaitForSeconds(interval);
        }
    }

    public void Activate()
    {
        enabled = true;
        calledToStart = true;
    }

    public void Deactivate()
    {
        enabled = false;
    }

}
