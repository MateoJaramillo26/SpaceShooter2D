using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEspacial : MonoBehaviour
{
    [SerializeField] public GameObject balaPrefab;
    [SerializeField] public float tiempoDesdeUltimoDisparo = 0f;
    [SerializeField] public float tiempoEntreDisparos = 0.5f;
    public float velocidad = 5f; // Velocidad de movimiento

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        Disparar();
    }

    void MoverNave()
    {
        // Obtener entrada del usuario
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en la entrada
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        // Mover la nave
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }

    void Disparar()
    {
        // Aumenta el tiempo desde el último disparo
        tiempoDesdeUltimoDisparo += Time.deltaTime;

        // Comprueba si el jugador presiona la tecla de disparo (barra espaciadora)
        if (Input.GetKeyDown(KeyCode.Space) && tiempoDesdeUltimoDisparo >= tiempoEntreDisparos)
        {
            // Resetea el temporizador de disparo
            tiempoDesdeUltimoDisparo = 0f;

            // Crear la bala en la posición de la nave
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

            // Obtener el Rigidbody2D de la bala y aplicar velocidad
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * 10f; // Ajusta la velocidad de la bala según tus necesidades
        }
    }
}
