using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreData", menuName = "ScriptableObjects/ScoreData")]
public class ScoreData : ScriptableObject
{
    public int puntaje = 0; // Puntaje actual del jugador.
    public int maxPuntaje = 0; // Mayor puntaje conseguido.
    public float tiempoParaSumarPuntaje = 10.0f; // Tiempo en segundos para sumar puntaje.
    private float tiempoTranscurrido = 0.0f;

    // Este booleano se utiliza para asegurarse de que el puntaje se inicie en 0 solo una vez en Start.
    private bool puntajeIniciado = false;

    public void StartGame()
    {

        if (!puntajeIniciado)
        {
            puntaje = 0; // Inicia el puntaje en 0 en el método StartGame.
            puntajeIniciado = true; // Marca el puntaje como iniciado.
        }
    }

    public void UpdateScore()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoParaSumarPuntaje)
        {
            puntaje += 100; // Aumenta el puntaje en 100.
            tiempoTranscurrido = 0.0f; // Reinicia el contador de tiempo.

            // Actualiza el mayor puntaje si el puntaje actual supera al mayor puntaje conseguido.
            if (puntaje > maxPuntaje)
            {
                maxPuntaje = puntaje;
            }
        }
    }

    
}
