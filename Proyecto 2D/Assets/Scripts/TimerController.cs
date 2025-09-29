using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float timeToWin = 60f; // segundos para victoria
    private float timer;
    public UIManager uiManager;
    public GameManager gameManager;

    private void Start()
    {
        timer = timeToWin;
    }

    private void Update()
    {
        if (gameManager.JuegoTerminado) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            uiManager.ActualizarTiempo(timer);

            if (timer <= 0)
            {
                gameManager.TerminarJuego();
            }
        }
    }
}