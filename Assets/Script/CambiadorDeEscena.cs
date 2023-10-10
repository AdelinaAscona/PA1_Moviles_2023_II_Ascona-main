using UnityEngine;
using UnityEngine.SceneManagement; 

public class CambiadorDeEscena : MonoBehaviour
{
    public void CambiarEscena(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena); // Cambia a la escena con el nombre proporcionado.
    }
}
