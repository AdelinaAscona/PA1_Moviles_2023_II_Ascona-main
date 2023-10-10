using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento vertical de las balas.

    private void Update()
    {
        // Mueve la bala hacia adelante en la direcci�n vertical.
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Si la bala sale de la pantalla, desact�vala.
        if (!IsInScreen())
        {
            gameObject.SetActive(false);
        }
    }

    private bool IsInScreen()
    {
        // Verifica si la bala est� dentro de la pantalla.
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPos.y > 0 && viewportPos.y < 1);
    }
}
