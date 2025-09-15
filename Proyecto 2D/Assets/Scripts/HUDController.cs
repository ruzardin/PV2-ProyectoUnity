using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI miTexto;

    public void ActualizarTextoHud(int puntos) 
    {
        miTexto.text = $"Vidas: {puntos}";
    }

}
