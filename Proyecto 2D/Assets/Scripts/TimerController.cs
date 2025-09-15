using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float timeToWin = 60f; // segundos para victoria
    private float timer;

    private void Start()
    {
        timer = timeToWin;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameEvents.TriggerVictory();
        }
    }
}