using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Ya existe una instancia de GameManager. Destruyendo duplicado.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool level1Started;
    public bool level1Completed;
    public bool level2Started;
    public bool level2Completed;
    public bool level3Started;
    public bool level3Completed;

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Veggie Venture!");
        UIManager.Instance.ActivateScreen(UIManager.UIScreen.StartScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
