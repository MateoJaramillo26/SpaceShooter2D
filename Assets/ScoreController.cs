using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Añade esto para acceder a las clases de TextMesh Pro

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Referencia al texto para mostrar el puntaje
    [SerializeField] private int contador = 0; // Contador de disparos

    // Propiedad pública para acceder al contador
    public int Contador
    {
        get { return contador; }
    }

    // Start is called before the first frame update
    void Start()
    {
        contador = 0; // Reiniciar contador al inicio del juego
        scoreText.text = $"{contador}"; // Mostrar el contador inicial
    }

    // Update is called once per frame
    void Update()
    {
        // Aquí puedes añadir lógica adicional si es necesario
    }

    public void AumentarScore()
    {
        Debug.Log("Contador aumenta");
        contador++; // Aumentar el contador en 1
        scoreText.text = $"{contador}"; // Actualizar el texto en pantalla
    }
}
