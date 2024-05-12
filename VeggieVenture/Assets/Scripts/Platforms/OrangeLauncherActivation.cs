using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeLauncherActivation : MonoBehaviour
{
    public OrangeLauncher orangeLauncher; // Referencia al OrangeLauncher que deseas activar

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            orangeLauncher.Activate();
            
        }
    }
}
