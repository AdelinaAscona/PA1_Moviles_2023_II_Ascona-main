using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo: MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento vertical

    private void Update()
    {
        // Mueve al enemigo hacia abajo en la direcci�n vertical.
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el enemigo sale de la pantalla, desact�valo o realiza alguna acci�n espec�fica.
        if (!IsInScreen())
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsInScreen()
    {
        // Verifica si el enemigo est� dentro de la pantalla.
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPos.y > 0 && viewportPos.y < 1);
    }
}
