using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = -10f; // Velocidad de la bala

    // Start is called before the first frame update
    void Start()
    {
        // Destruir la bala después de 5 segundos si no ha colisionado
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }
}