using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Nave;
    public float tiempoEntreApariciones = 3f; // Tiempo entre apariciones
    // Start is called before the first frame update
    void Start()
    {
        // Iniciar la coroutine para generar enemigos
        StartCoroutine(GenerarEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            // Esperar el tiempo especificado
            yield return new WaitForSeconds(tiempoEntreApariciones);

            // Generar la posición aleatoria en Y
            float posicionY = Random.Range(4f, 2.096f); // Ajusta el rango según necesites
            Vector3 posicionInicial = new Vector3(Random.Range(-2f, 2f), posicionY, 0f); // Cambia el rango de X según tu pantalla

            // Instanciar la nave enemiga en la posición inicial con rotación de 180 grados
            Instantiate(Nave, posicionInicial, Quaternion.Euler(0, 0, 180));
        }
    }
}
