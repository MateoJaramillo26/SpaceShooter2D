using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject Nave;
    public float velocidad = 2f; // Velocidad de movimiento de la nave enemiga
    public float tiempoEntreApariciones = 3f; // Tiempo entre apariciones
    [SerializeField] private UnityEvent naveMuere = new();

    private ScoreController scoreController; // Referencia al ScoreController

    // Start is called before the first frame update
    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once por frame
    void Update()
    {
        MoverEnemigo();
    }

    void MoverEnemigo()
    {
        // Mover la nave hacia arriba (hacia adelante en su dirección)
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);

        // Destruir la nave si se sale de la pantalla (ajusta el valor de Y según tu pantalla)
        if (transform.position.y > 6) // Cambia la condición para el límite superior
        {
            Destroy(Nave);
        }
    }


    // Detectar colisiones con la bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name); // Mensaje de debug
        if (collision.CompareTag("Bala"))
        {
            naveMuere.Invoke();
            // Destruir la nave enemiga
            scoreController.AumentarScore();
            if (scoreController.Contador >= 10)
            {
                GameOver();
            }
            Destroy(Nave);
            // También puedes destruir la bala si quieres que desaparezca al impactar
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        Debug.Log("¡Ganaste!");
        // Aquí puedes añadir una pantalla de victoria si lo deseas
    }
}
