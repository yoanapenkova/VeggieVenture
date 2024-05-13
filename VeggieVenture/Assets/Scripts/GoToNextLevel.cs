using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador ha colisionado con el suelo
        if (other.CompareTag("Fridge"))
        {
            if (GameManager.Instance.level3Started)
            {
                UIManager.Instance.DeactivateScreen(UIManager.UIScreen.Level3Screen);
                UIManager.Instance.DeactivateScreen(UIManager.UIScreen.HudScreen);
                UIManager.Instance.ActivateScreen(UIManager.UIScreen.VictoryScreen);
                GameManager.Instance.level3Completed = true;
            } else if (GameManager.Instance.level2Started)
            {
                UIManager.Instance.DeactivateScreen(UIManager.UIScreen.Level2Screen);
                UIManager.Instance.ActivateScreen(UIManager.UIScreen.Level3Screen);
                GameManager.Instance.level2Completed = true;
                GameManager.Instance.level3Started = true;

                GameObject Player = GameObject.Find("Player");
                GameObject LVL3StartingPoint = GameObject.Find("LVL3StartingPoint");

                Player.transform.position = LVL3StartingPoint.transform.position;
                Player.transform.rotation = LVL3StartingPoint.transform.rotation;
            } else if (GameManager.Instance.level1Started)
            {
                UIManager.Instance.DeactivateScreen(UIManager.UIScreen.Level1Screen);
                UIManager.Instance.ActivateScreen(UIManager.UIScreen.Level2Screen);
                GameManager.Instance.level1Completed = true;
                GameManager.Instance.level2Started = true;

                GameObject Player = GameObject.Find("Player");
                GameObject LVL2StartingPoint = GameObject.Find("LVL2StartingPoint");

                Player.transform.position = LVL2StartingPoint.transform.position;
                Player.transform.rotation = LVL2StartingPoint.transform.rotation;
            }
        }
    }
}
