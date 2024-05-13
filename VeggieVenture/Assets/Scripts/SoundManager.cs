using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ambientSound; // Referencia al AudioSource para el sonido ambiente

    public static SoundManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Ya existe una instancia de SoundManager. Destruyendo duplicado.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (ambientSound != null && ambientSound.clip != null)
        {
            ambientSound.loop = true;
            ambientSound.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource o clip de sonido ambiente no asignado en el SoundManager.");
        }
    }
}
