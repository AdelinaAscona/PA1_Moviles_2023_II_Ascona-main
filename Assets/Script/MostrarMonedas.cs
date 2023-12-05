using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarMonedas : MonoBehaviour
{
    public PlayerMonedas playerMonedas;
    public TMP_Text textoMonedas;

    private void Update()
    {
        if (playerMonedas != null && textoMonedas != null)
        {
            // Muestra la vida actual en el objeto de TextMeshPro.
            textoMonedas.text = "Monedas: " + playerMonedas.currentMonedas;
        }
    }
}
