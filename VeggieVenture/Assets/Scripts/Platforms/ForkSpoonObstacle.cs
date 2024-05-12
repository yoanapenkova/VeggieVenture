using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkSpoonObstacle : MonoBehaviour
{
    // Velocidad de rotación
    public float rotationSpeed = 90f; // Grados por segundo

    // Objetos hijo (tenedor y cuchara)
    public Transform fork;
    public Transform spoon;

    void Update()
    {
        // Rotar el tenedor y la cuchara
        RotateUtensil(fork);
        RotateUtensil(spoon);
    }

    // Método para rotar un utensilio
    void RotateUtensil(Transform utensil)
    {
        if (utensil != null)
        {
            // Calcular el ángulo de rotación
            float rotationAngle = rotationSpeed * Time.deltaTime;

            // Aplicar la rotación en el eje Z
            utensil.Rotate(0f, 0f, rotationAngle);
        }
    }
}
