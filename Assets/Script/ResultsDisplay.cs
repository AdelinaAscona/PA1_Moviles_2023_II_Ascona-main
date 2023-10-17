using UnityEngine;

public class ResultsDisplay : MonoBehaviour
{
    private void Start()
    {
        // Desactiva los objetos al inicio.
        SetObjectsActive(false);
    }

    // Funci�n para activar o desactivar objetos en funci�n del estado del juego.
    public void SetObjectsActive(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}

