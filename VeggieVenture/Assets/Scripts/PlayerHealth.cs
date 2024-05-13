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
            GameObject life1Object = GameObject.Find("Life1");
            life1Object.SetActive(false);

            //Dirigir a pantalla de Game Over
            Debug.Log("Oh oh");

            animator.Play("Die");
            //StartCoroutine(WaitAndShowGameOverScreen());
            UIManager.Instance.ShowGameOverScreen();

        } else if (currentLives <=1)
        {
            GameObject life2Object = GameObject.Find("Life2");
            life2Object.SetActive(false);
        } else if (currentLives <=2)
        {
            GameObject life3Object = GameObject.Find("Life3");
            life3Object.SetActive(false);
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

    IEnumerator WaitAndShowGameOverScreen() {
        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Call your function here
        UIManager.Instance.ShowGameOverScreen();
    }
}

