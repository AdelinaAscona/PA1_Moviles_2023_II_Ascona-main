using UnityEngine;
using TMPro;

public class MostrarVida : MonoBehaviour
{
    public PlayerHealth playerHealth; // Arrastra el ScriptableObject de la vida del jugador aquí desde el Inspector.
    public TMP_Text textoVida; // Arrastra el objeto de TextMeshPro aquí desde el Inspector.

    private void Update()
    {
        if (playerHealth != null && textoVida != null)
        {
            // Muestra la vida actual en el objeto de TextMeshPro.
            textoVida.text = "Vida: " + playerHealth.currentHealth;
        }
    }
}