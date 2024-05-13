using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxLives = 3f; // Vidas máximas del jugador
    public float currentLives; // Vidas actuales del jugador
    private Animator animator;
    public bool canTakeDamage = true;

    void Start()
    {
        currentLives = maxLives;
        animator = GetComponent<Animator>();
    }

    public void LoseLife()
    {
        currentLives -= 1;
        Debug.Log("te quedan " + currentLives + " vidas");
        canTakeDamage = false;
    
        if (currentLives <= 0)
        {
            //Dirigir a pantalla de Game Over
            Debug.Log("Oh oh");

            animator.Play("Die");
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

    public void EnableDamage(){
        canTakeDamage = true;
    }
}

