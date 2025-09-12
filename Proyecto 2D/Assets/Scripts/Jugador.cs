using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private int vida = 5;

    public UnityEvent<int> OnLivesChanged;

    public void ModificarVida(int puntos)
    {
        vida += puntos;
        OnLivesChanged.Invoke(vida);
        Debug.Log(EstasVivo());

        if (vida <= 0)
        {
            // Aqu� puedes manejar la situaci�n de Game Over
        }
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }
    
}
