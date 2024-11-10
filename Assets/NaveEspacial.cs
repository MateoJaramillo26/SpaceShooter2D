using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEspacial : MonoBehaviour
{
    [SerializeField] public GameObject balaPrefab;
    [SerializeField] public float tiempoDesdeUltimoDisparo = 0f;
    [SerializeField] public float tiempoEntreDisparos = 0.5f;
    public float velocidad = 5f; // Velocidad de movimiento
    public float velocidadBala = 10f; // Velocidad de la bala

    private ScoreController scoreController; // Referencia al ScoreController

    void Start()
    {
        // Obtener el componente ScoreController del objeto de la escena
        scoreController = FindObjectOfType<ScoreController>();
    }

    void Update()
    {
        MoverNave();
        Disparar();
    }

    void MoverNave()
    {
        // Obtener entrada del usuario con teclas invertidas
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en la entrada
        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0);

        // Mover la nave
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }

    void Disparar()
    {
        // Aumenta el tiempo desde el último disparo
        tiempoDesdeUltimoDisparo += Time.deltaTime;

        // Comprueba si el jugador presiona la tecla de disparo (barra espaciadora) y si ha pasado el tiempo necesario entre disparos
        if (Input.GetKeyDown(KeyCode.Space) && tiempoDesdeUltimoDisparo >= tiempoEntreDisparos)
        {
            // Resetea el temporizador de disparo
            tiempoDesdeUltimoDisparo = 0f;

            // Crear la bala en la posición de la nave
            GameObject bala = Instantiate(balaPrefab, transform.position, transform.rotation);

            // Obtener el componente Rigidbody de la bala y aplicarle una velocidad en dirección contraria
            Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
            if (rbBala != null)
            {
                rbBala.velocity = transform.up * velocidadBala; // La bala se moverá en la dirección opuesta
            }

        }
    }


}
