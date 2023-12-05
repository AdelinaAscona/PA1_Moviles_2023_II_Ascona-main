using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5.0f; 
    public ScoreData scoreData;

    public PlayerMonedas playerMonedas;
    public PlayerHealth playerHealth; 

    private Rigidbody2D rb;
    private Vector2 initialPosition; 
    private bool isMoving = false;
    private Vector2 targetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position; 

        // Inicializa jugador con la salud máxima.
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    private void Update()
    {
        // Actualiza el puntaje
        scoreData.UpdateScore();

        if (isMoving)
        {
            // Calcula la dirección horizontal hacia la posición objetivo.
            Vector2 moveDirection = new Vector2(0, targetPosition.y - rb.position.y).normalized;

            rb.velocity = new Vector2(rb.velocity.x, moveDirection.y * moveSpeed);

            if (Mathf.Abs(rb.position.y - targetPosition.y) < 0.1f)
            {
                isMoving = false;
                rb.velocity = new Vector2(rb.velocity.y, 0);
            }
        }
        else
        {
            // movimiento horizontal.
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Al inicio del toque, registra la posición del toque.
                    Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                    targetPosition = new Vector2(rb.position.x, touchWorldPos.y);

                    isMoving = true;
                }
            }
        }

        // Verifica si la vida del jugador llega a 0 y cambia de escena.
        if (playerHealth.currentHealth <= 0)
        {
            ActivateObjectsInPuntajeMaxScene();
            ChangeSceneAndResetHealth();

        }
    }

    //Vida y monedas del personaje
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Slime"))
        {
            playerHealth.currentHealth -= 1;

            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Coin"))
        {
            playerMonedas.currentMonedas += 10;

            other.gameObject.SetActive(false);
        }
    }


    private void ChangeSceneAndResetHealth()
    {
        // Restablece la vida del jugador a 3.
        playerHealth.currentHealth = 3;
    }

    private void ActivateObjectsInPuntajeMaxScene()
    {
        // Encuentra todos los objetos desactivados en la escena "PuntajeMax" y activa.
        Scene puntajeMaxScene = SceneManager.GetSceneByName("PuntajeMax");
        if (puntajeMaxScene.IsValid())
        {
            GameObject[] objectsInScene = puntajeMaxScene.GetRootGameObjects();
            foreach (GameObject obj in objectsInScene)
            {
                obj.SetActive(true);
            }
        }
    }
}
