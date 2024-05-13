using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public void HideHUDScreen()
    {
        HUDScreen.SetActive(false);
    }

    // Método para mostrar el GameOver
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        HideHUDScreen();
        levelOne.SetActive(false);
        
        /*
        // Find existing Event System, if any
        EventSystem existingEventSystem = FindObjectOfType<EventSystem>();
        
        // Destroy existing Event System
        if (existingEventSystem != null)
        {
            Destroy(existingEventSystem.gameObject);
        }

        // Create a new Event System
        GameObject eventSystemObject = new GameObject("EventSystem");
        EventSystem newEventSystem = eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>(); // Or any other input module you need
        */

        Cursor.visible = true;
    }

    // Método para ocultar el GameOver
    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    // Método para manejar el evento de clic en el botón de inicio
    public void StartGame()
    {
        // Aquí colocarías la lógica para iniciar el juego
        Debug.Log("Starting game...");
        ShowHUDScreen();
        HideStartScreen();
        EnableLevel(levelOne);
    }

    public void EnableLevel(GameObject level){
        level.SetActive(true);
    }
}
