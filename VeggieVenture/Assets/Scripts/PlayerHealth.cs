using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxLives = 3f; // Vidas máximas del jugador
    private float currentLives; // Vidas actuales del jugador

    void Start()
    {
        currentLives = maxLives;
    }

    public void LoseLife()
    {
        currentLives -= 1;
        Debug.Log("te quedan " + currentLives + " vidas");
    
        if (currentLives <= 0)
        {
            //Dirigir a pantalla de Game Over
            Debug.Log("Oh oh");
        }
    }

    public float GetCurrentLives()
    {
        return currentLives;
    }

    private void RestartScene()
    {
        currentLives = 3f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

    }
}

