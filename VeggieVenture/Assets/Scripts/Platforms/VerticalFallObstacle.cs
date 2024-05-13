using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFallObstacle : MonoBehaviour
{
    public float upTimeMin = 0.5f;
    public float upTimeMax = 1f;
    public float upDistance = 1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveKnife());
    }

    IEnumerator MoveKnife()
    {
        while (true)
        {
            // Levantar el cuchillo
            yield return MoveKnifeToPosition(initialPosition + Vector3.up * upDistance, Random.Range(upTimeMin, upTimeMax));

            // Esperar un tiempo aleatorio
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));

            // Bajar el cuchillo
            yield return MoveKnifeToPosition(initialPosition, Random.Range(upTimeMin, upTimeMax));

            // Esperar un tiempo aleatorio antes de volver a levantarse
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }

    IEnumerator MoveKnifeToPosition(Vector3 targetPosition, float time)
    {
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, targetPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
