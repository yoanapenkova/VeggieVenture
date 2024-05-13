using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{

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

    public enum UIScreen
    {
        StartScreen,
        Level1Screen,
        Level2Screen,
        Level3Screen,
        GameOverScreen,
        HudScreen,
        VictoryScreen,
        ControlsScreen,
        CreditsScreen,
        PauseScreen,
        SettingsScreen,
        // Add more screens as needed
    }

    public GameObject startScreenPanel;
    public GameObject level1ScreenPanel;
    public GameObject level2ScreenPanel;
    public GameObject level3ScreenPanel;
    public GameObject gameOverScreenPanel;
    public GameObject hudScreenPanel;
    public GameObject victoryScreenPanel;
    public GameObject controlsScreenPanel;
    public GameObject creditsScreenPanel;
    public GameObject pauseScreenPanel;
    public GameObject settingsScreenPanel;
    // Reference other UI panels as needed

    private UIScreen previousScreen;

    public void ActivateScreen(UIScreen screen)
    {
        switch (screen)
        {
            case UIScreen.StartScreen:
                startScreenPanel.SetActive(true);
                break;
            case UIScreen.Level1Screen:
                level1ScreenPanel.SetActive(true);
                break;
            case UIScreen.Level2Screen:
                level2ScreenPanel.SetActive(true);
                break;
            case UIScreen.Level3Screen:
                level3ScreenPanel.SetActive(true);
                break;
            case UIScreen.GameOverScreen:
                gameOverScreenPanel.SetActive(true);
                break;
            case UIScreen.HudScreen:
                hudScreenPanel.SetActive(true);
                break;
            case UIScreen.VictoryScreen:
                victoryScreenPanel.SetActive(true);
                break;
            case UIScreen.ControlsScreen:
                controlsScreenPanel.SetActive(true);
                break;
            case UIScreen.CreditsScreen:
                creditsScreenPanel.SetActive(true);
                break;
            case UIScreen.PauseScreen:
                pauseScreenPanel.SetActive(true);
                break;
            case UIScreen.SettingsScreen:
                settingsScreenPanel.SetActive(true);
                break;
            // Handle other screens
        }
    }

    public void DeactivateScreen(UIScreen screen)
    {
        switch (screen)
        {
            case UIScreen.StartScreen:
                startScreenPanel.SetActive(false);
                break;
            case UIScreen.Level1Screen:
                level1ScreenPanel.SetActive(false);
                break;
            case UIScreen.Level2Screen:
                level2ScreenPanel.SetActive(false);
                break;
            case UIScreen.Level3Screen:
                level3ScreenPanel.SetActive(false);
                break;
            case UIScreen.GameOverScreen:
                gameOverScreenPanel.SetActive(false);
                break;
            case UIScreen.HudScreen:
                hudScreenPanel.SetActive(false);
                break;
            case UIScreen.VictoryScreen:
                victoryScreenPanel.SetActive(false);
                break;
            case UIScreen.ControlsScreen:
                controlsScreenPanel.SetActive(false);
                break;
            case UIScreen.CreditsScreen:
                creditsScreenPanel.SetActive(false);
                break;
            case UIScreen.PauseScreen:
                pauseScreenPanel.SetActive(false);
                break;
            case UIScreen.SettingsScreen:
                settingsScreenPanel.SetActive(false);
                break;
            // Handle other screens
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Start Menu
        if (startScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.K))
            {
                DeactivateScreen(UIScreen.StartScreen);
                ActivateScreen(UIScreen.ControlsScreen);
                previousScreen = UIScreen.StartScreen;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                DeactivateScreen(UIScreen.StartScreen);
                ActivateScreen(UIScreen.SettingsScreen);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                DeactivateScreen(UIScreen.StartScreen);
                ActivateScreen(UIScreen.CreditsScreen);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                DeactivateScreen(UIScreen.StartScreen);
                ActivateScreen(UIScreen.Level1Screen);
                ActivateScreen(UIScreen.HudScreen);
                GameManager.Instance.level1Started = true;
                GameManager.Instance.startTime = Time.time;

                GameObject Player = GameObject.Find("Player");
                GameObject LVL1StartingPoint = GameObject.Find("LVL1StartingPoint");

                Player.transform.position = LVL1StartingPoint.transform.position;
                Player.transform.rotation = LVL1StartingPoint.transform.rotation;
            }
        }

        // Victory Menu
        if (victoryScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.M))
            {
                DeactivateScreen(UIScreen.VictoryScreen);
                ActivateScreen(UIScreen.StartScreen);

                GameManager.Instance.level1Started = false;
                GameManager.Instance.level1Completed = false;
                GameManager.Instance.level2Started = false;
                GameManager.Instance.level2Completed = false;
                GameManager.Instance.level3Started = false;
                GameManager.Instance.level3Completed = false;
            }
        }

        // Game Over Menu
        if (gameOverScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.M))
            {
                DeactivateScreen(UIScreen.GameOverScreen);
                ActivateScreen(UIScreen.StartScreen);

                GameManager.Instance.level1Started = false;
                GameManager.Instance.level1Completed = false;
                GameManager.Instance.level2Started = false;
                GameManager.Instance.level2Completed = false;
                GameManager.Instance.level3Started = false;
                GameManager.Instance.level3Completed = false;
            }
        }

        // Controls Menu
        if (controlsScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.B))
            {
                DeactivateScreen(UIScreen.ControlsScreen);
                ActivateScreen(previousScreen);
            }
        }

        // Credits Menu
        if (creditsScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.B))
            {
                DeactivateScreen(UIScreen.CreditsScreen);
                ActivateScreen(UIScreen.StartScreen);
            }
        }

        // Pause Menu
        if (pauseScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.S))
            {
                DeactivateScreen(UIScreen.PauseScreen);
                ActivateScreen(UIScreen.SettingsScreen);
                previousScreen = UIScreen.PauseScreen;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                DeactivateScreen(UIScreen.PauseScreen);
                ActivateScreen(UIScreen.StartScreen);
                GameManager.Instance.level1Started = false;
                GameManager.Instance.level1Completed = false;
                GameManager.Instance.level2Started = false;
                GameManager.Instance.level2Completed = false;
                GameManager.Instance.level3Started = false;
                GameManager.Instance.level3Completed = false;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                DeactivateScreen(UIScreen.PauseScreen);
                ActivateScreen(UIScreen.HudScreen);
                ActivateScreen(previousScreen);
            }
        }

        // Settings Menu
        if (settingsScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.B))
            {
                DeactivateScreen(UIScreen.SettingsScreen);
                ActivateScreen(previousScreen);
            }
        }

        // Level 1 Menu
        if (level1ScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DeactivateScreen(UIScreen.HudScreen);
                ActivateScreen(UIScreen.PauseScreen);
                previousScreen = UIScreen.Level1Screen;
            }
        }

        // Level 2 Menu
        if (level2ScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DeactivateScreen(UIScreen.HudScreen);
                ActivateScreen(UIScreen.PauseScreen);
                previousScreen = UIScreen.Level2Screen;
            }
        }

        // Level 3 Menu
        if (level3ScreenPanel.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DeactivateScreen(UIScreen.HudScreen);
                ActivateScreen(UIScreen.PauseScreen);
                previousScreen = UIScreen.Level3Screen;
            }
        }
    }
}
