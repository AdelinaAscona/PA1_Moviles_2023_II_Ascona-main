using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] spawnPoints; // Arreglo de puntos de aparición de enemigos.
    public float spawnInterval = 2.0f; // Intervalo de tiempo entre la aparición de enemigos.

    public GameObject enemyPrefabType1; // Prefab del primer tipo de enemigo.
    public GameObject enemyPrefabType2; // Prefab del segundo tipo de enemigo.

    private float lastSpawnTime;
    private ObjectPool<Transform> enemyPoolType1;
    private ObjectPool<Transform> enemyPoolType2;

    private void Start()
    {
        lastSpawnTime = Time.time;

        // Inicializa los pools de enemigos para cada tipo.
        enemyPoolType1 = new ObjectPool<Transform>(enemyPrefabType1.GetComponent<Transform>(), 10);
        enemyPoolType2 = new ObjectPool<Transform>(enemyPrefabType2.GetComponent<Transform>(), 10);
    }

    private void Update()
    {
        // Verifica si ha pasado suficiente tiempo desde la última aparición.
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            // Escoge aleatoriamente un tipo de enemigo (1 o 2).
            int enemyType = Random.Range(1, 3);

            // Escoge aleatoriamente uno de los puntos de spawn.
            GameObject selectedSpawnPointObject = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Transform selectedSpawnPoint = selectedSpawnPointObject.transform;

            // Obtén un enemigo del pool correspondiente al tipo seleccionado.
            Transform enemy = (enemyType == 1) ? enemyPoolType1.GetObject() : enemyPoolType2.GetObject();

            // Configura la posición del enemigo en el punto de spawn seleccionado.
            enemy.position = selectedSpawnPoint.position;

            // Activa el enemigo.
            enemy.gameObject.SetActive(true);

            // Actualiza el tiempo de la última aparición.
            lastSpawnTime = Time.time;
        }
    }
}
