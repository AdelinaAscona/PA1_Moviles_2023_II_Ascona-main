using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public ScoreData scoreData; // Referencia al ScriptableObject del puntaje.

    // Asigna la referencia al ScoreData cuando se inicializa el objeto Trash.
    public void Initialize(ScoreData scoreData)
    {
        this.scoreData = scoreData;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Desactiva el objeto "Trash" al colisionar con un objeto con el tag "Bullet".
            gameObject.SetActive(false);

            // Aumenta el puntaje en 100 cuando colisiona con una bala.
            if (scoreData != null)
            {
                scoreData.puntaje += 500;
            }
        }
    }
}
