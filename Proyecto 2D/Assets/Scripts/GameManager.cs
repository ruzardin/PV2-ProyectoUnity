using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private bool juegoTerminado = false;

    public bool JuegoTerminado => juegoTerminado;
    private bool isPaused = false;


    private void OnEnable()
    {
        if (uiManager == null)
        {
            uiManager = Object.FindFirstObjectByType<UIManager>();
        }
        GameEvents.OnGameOver += ShowGameOverMenu;
        GameEvents.OnVictory += ShowVictoryMenu;
        GameEvents.OnPause += Pause;
        GameEvents.OnResume += Resume;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverMenu;
        GameEvents.OnVictory -= ShowVictoryMenu;
        GameEvents.OnPause -= Pause;
        GameEvents.OnResume -= Resume;
    }

    private void Update()
    {
        if (juegoTerminado) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                GameEvents.TriggerResume();
            }
            else
            {
                GameEvents.TriggerPause();
            }
        }
    }

    public void TerminarJuego()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Time.timeScale = 0;
        GameEvents.TriggerVictory();
        uiManager.MostrarVictoria();
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        uiManager.MostrarPausa();
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        uiManager.OcultarPausa();
    }

    private void ShowGameOverMenu()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Time.timeScale = 0;
        if (uiManager != null)
        {
            uiManager.MostrarGameOver();
        }
    }
   
    private void ShowVictoryMenu()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Time.timeScale = 0;
        if (uiManager != null)
        {
            uiManager.MostrarVictoria();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}