using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int vidas = 3;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private UIManager uiManager;
    private bool juegoTerminado = false;

    public bool JuegoTerminado => juegoTerminado;
    private bool isPaused = false;

    private void OnEnable()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife(); // Reduce vida y dispara GameOver si llega a 0
        }
        else if (collision.gameObject.CompareTag("Victory"))
        {
            GameEvents.TriggerVictory();
        }
    }

    public void LoseLife()
    {

        if (juegoTerminado) return;

        vidas--;
        uiManager.ActualizarVidas(vidas);

        if (vidas <= 0)
        {
            juegoTerminado = true;
            Time.timeScale = 0; // Pausar juego
            GameEvents.TriggerGameOver();
        }
    }

    public void TerminarJuego()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        Time.timeScale = 0;
        GameEvents.TriggerVictory();
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
        uiManager.MostrarGameOver();
        
    }

    private void ShowVictoryMenu()
    {
        uiManager.MostrarVictoria();
        
    }

    public void RestartScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}