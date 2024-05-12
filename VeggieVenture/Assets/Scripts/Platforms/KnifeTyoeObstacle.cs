using UnityEngine;
using System.Collections;

public class KnifeTypeObstacle : MonoBehaviour
{
    public float rotationSpeed = 180f; // Velocidad de rotación del cuchillo (grados por segundo)
    public float upTimeMin = 0.1f; // Tiempo mínimo de levantamiento del cuchillo
    public float upTimeMax = 0.3f; // Tiempo máximo de levantamiento del cuchillo

    private Quaternion initialRotation; // Rotación inicial del cuchillo

    void Start()
    {
        initialRotation = transform.rotation;
        StartCoroutine(MoveKnife());
    }

    IEnumerator MoveKnife()
    {
        while (true)
        {
            // Rotar el cuchillo hacia arriba
            yield return RotateKnife(initialRotation * Quaternion.Euler(0f, -90f, 0f), Random.Range(upTimeMin, upTimeMax));

            // Esperar un tiempo aleatorio
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));

            // Rotar el cuchillo hacia abajo
            yield return RotateKnife(initialRotation, Random.Range(upTimeMin, upTimeMax));

            // Esperar un tiempo aleatorio antes de volver a rotar hacia arriba
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }

    IEnumerator RotateKnife(Quaternion targetRotation, float time)
    {
        float elapsedTime = 0f;
        Quaternion startingRot = transform.rotation;

        while (elapsedTime < time)
        {
            transform.rotation = Quaternion.Slerp(startingRot, targetRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
