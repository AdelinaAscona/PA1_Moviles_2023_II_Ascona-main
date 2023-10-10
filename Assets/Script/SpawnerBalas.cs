using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalas : MonoBehaviour
{
    public PoolingBalas bulletPool; // Referencia al Object Pool de balas.
    public Transform spawnPoint; // Punto de aparici�n de la bala.
    public float burstInterval = 0.5f; // Intervalo entre r�fagas de balas (en segundos).
    public int bulletsPerBurst = 1; // Cantidad de balas por r�faga.

    private bool isHolding = false;
    private float lastBurstTime;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isHolding = true;
                lastBurstTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isHolding = false;
            }
        }

        if (isHolding)
        {
            // Verifica si ha pasado suficiente tiempo desde la �ltima r�faga.
            if (Time.time - lastBurstTime >= burstInterval)
            {
                // Genera una r�faga de balas.
                for (int i = 0; i < bulletsPerBurst; i++)
                {
                    GameObject bullet = bulletPool.GetObjectFromPool();
                    bullet.transform.position = spawnPoint.position;
                    bullet.SetActive(true);
                }

                lastBurstTime = Time.time; // Registra el tiempo de la �ltima r�faga.
            }
        }
    }
}
