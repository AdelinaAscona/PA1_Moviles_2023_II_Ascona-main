using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MostrarPuntajeMaximo : MonoBehaviour
{
    public ScoreData scoreData; // Arrastra el ScriptableObject del puntaje aqu� desde el Inspector.
    public TMP_Text textoPuntajeMaximo; // Arrastra el objeto de TextMeshPro aqu� desde el Inspector.

    private void Start()
    {
        if (scoreData != null && textoPuntajeMaximo != null)
        {
            // Muestra solo el puntaje m�ximo en el objeto de TextMeshPro.
            textoPuntajeMaximo.text = scoreData.maxPuntaje.ToString();
        }
    }
}
