using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Velocidad de movimiento horizontal del jugador.
    public ScoreData scoreData; // Referencia al ScriptableObject del puntaje.

    public PlayerHealth playerHealth; // Referencia al ScriptableObject de la salud del jugador.

    private Rigidbody2D rb;
    private Vector2 initialPosition; // Posición inicial del jugador.
    private bool isMoving = false;
    private Vector2 targetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position; // Guarda la posición inicial del jugador.

        // Inicializa la salud actual del jugador con la salud máxima.
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    private void Update()
    {
        // Actualiza el puntaje desde el ScriptableObject.
        scoreData.UpdateScore();

        if (isMoving)
        {
            // Calcula la dirección horizontal hacia la posición objetivo.
            Vector2 moveDirection = new Vector2(0, targetPosition.y - rb.position.y).normalized;

            // Mueve al jugador horizontalmente en la dirección calculada.
            rb.velocity = new Vector2(rb.velocity.x, moveDirection.y * moveSpeed);

            // Si el jugador está cerca de la posición objetivo en el eje y, detén el movimiento horizontal.
            if (Mathf.Abs(rb.position.y - targetPosition.y) < 0.1f)
            {
                isMoving = false;
                rb.velocity = new Vector2(rb.velocity.y, 0);
            }
        }
        else
        {
            // Detiene el movimiento horizontal.
            rb.velocity = new Vector2(0, rb.velocity.y);

            // Detecta el toque en la pantalla.
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Al inicio del toque, registra la posición del toque.
                    Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                    targetPosition = new Vector2(rb.position.x, touchWorldPos.y);

                    // Inicia el movimiento horizontal hacia la posición tocada.
                    isMoving = true;
                }
            }
        }

        // Verifica si la vida del jugador llega a 0 y cambia de escena.
        if (playerHealth.currentHealth <= 0)
        {
            ChangeSceneAndResetHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Slime"))
        {
            // Resta 1 a la salud actual cuando colisiona con un objeto "Enemy" o "Trash".
            playerHealth.currentHealth -= 1;

            // Realiza alguna acción adicional, como desactivar el objeto colisionado.
            other.gameObject.SetActive(false);
        }
    }

    // Función para cambiar la escena y restablecer la vida del jugador a 3.
    private void ChangeSceneAndResetHealth()
    {
        // Cambia a la escena deseada (reemplaza "NombreDeTuEscena" por el nombre correcto de tu escena).
        SceneManager.LoadScene("PuntajeMax");

        // Restablece la vida del jugador a 3.
        playerHealth.currentHealth = 3;
    }
}
