using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject startScreen;
    public GameObject controlsScreen;
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject HUDScreen;
    public GameObject pauseScreen;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public GameObject levelOne;

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Ya existe una instancia de UIManager. Destruyendo duplicado.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Al iniciar, mostramos el objeto StartScreen
        ShowStartScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método para mostrar el StartScreen
    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        CursorManager.Instance.ShowCursor();
    }

    // Método para ocultar el StartScreen
    public void HideStartScreen()
    {
        startScreen.SetActive(false);
    }

    // Método para mostrar el HUDScreen
    public void ShowHUDScreen()
    {
        HUDScreen.SetActive(true);
        CursorManager.Instance.ShowCursor();
    }

    // Método para ocultar el HUDScreen
    public void HideHUDcreen()
    {
        HUDScreen.SetActive(false);
    }

    // Método para mostrar el GameOver
    public void ShowGameOverScreen()
    {
        HUDScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        levelOne.SetActive(false);
        Cursor.visible = true;
    }

    // Método para ocultar el GameOver
    public void HideGameOvercreen()
    {
        gameOverScreen.SetActive(false);
    }

    // Método para manejar el evento de clic en el botón de inicio
    public void StartGame()
    {
        // Aquí colocarías la lógica para iniciar el juego
        Debug.Log("Starting game...");
        HideStartScreen();
        EnableLevel(levelOne);
        ShowHUDScreen();
    }

    public void EnableLevel(GameObject level){
        level.SetActive(true);
    }
}
