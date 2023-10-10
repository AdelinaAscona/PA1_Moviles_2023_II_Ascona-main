using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreData scoreData; // Asigna la referencia al ScriptableObject del puntaje en el Inspector.

    void Start()
    {
        if (scoreData != null)
        {
            scoreData.puntaje = 0; // Inicia el puntaje en 0 al principio del juego.
        }
    }
}
