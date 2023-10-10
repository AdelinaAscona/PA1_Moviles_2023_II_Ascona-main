using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo: MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento vertical

    private void Update()
    {
        // Mueve al enemigo hacia abajo en la dirección vertical.
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el enemigo sale de la pantalla, desactívalo o realiza alguna acción específica.
        if (!IsInScreen())
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsInScreen()
    {
        // Verifica si el enemigo está dentro de la pantalla.
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPos.y > 0 && viewportPos.y < 1);
    }
}
