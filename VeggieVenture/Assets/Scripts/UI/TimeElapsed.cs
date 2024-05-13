using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeElapsed : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula el tiempo transcurrido desde el inicio del juego
        float elapsedTime = Time.time - GameManager.Instance.startTime;

        // Formatea el tiempo en formato mm:ss
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        // Actualiza el texto del temporizador en el objeto de TextMeshPro
        timerText.text = minutes + ":" + seconds;
    }
}
