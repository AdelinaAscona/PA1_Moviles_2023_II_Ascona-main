using UnityEngine;
using TMPro;

public class MostrarPuntaje : MonoBehaviour
{
    public ScoreData scoreData; // Arrastra el ScriptableObject del puntaje aqu� desde el Inspector.
    public TMP_Text textoPuntaje; // Arrastra el objeto de TextMeshPro aqu� desde el Inspector.

    private void Update()
    {
        if (scoreData != null && textoPuntaje != null)
        {
            // Muestra el puntaje actual en el objeto de TextMeshPro.
            textoPuntaje.text = "Puntaje: " + scoreData.puntaje;
        }
    }
}
