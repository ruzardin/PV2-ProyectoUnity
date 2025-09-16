using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI vidasText;
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    public GameObject pauseMenu;

    public void ActualizarVidas(int vidas)
    {
        vidasText.text = "Vidas: " + vidas;
    }

    public void ActualizarTiempo(float tiempo)
    {
        timerText.text = "Tiempo: " + Mathf.Ceil(tiempo).ToString();
    }

    public void MostrarGameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void MostrarVictoria()
    {
        victoryMenu.SetActive(true);
    }

    public void MostrarPausa()
    {
        pauseMenu.SetActive(true);
    }

    public void OcultarPausa()
    {
        pauseMenu.SetActive(false);
    }
}