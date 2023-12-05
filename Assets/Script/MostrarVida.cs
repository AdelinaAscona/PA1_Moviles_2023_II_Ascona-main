using UnityEngine;
using TMPro;

public class MostrarVida : MonoBehaviour
{
    public PlayerHealth playerHealth; 
    public TMP_Text textoVida; 

    private void Update()
    {
        if (playerHealth != null && textoVida != null)
        {
            // Muestra la vida actual en el objeto de TextMeshPro.
            textoVida.text = "Vida: " + playerHealth.currentHealth;
        }
    }
}