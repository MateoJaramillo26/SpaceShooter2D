using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to access TextMesh Pro classes

public class ScoreController : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        scoreText.text = $"{contador}"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarScore()
    {
        Debug.Log("Contador aumenta");
        contador = contador + 1;
        scoreText.text = $"{contador}"; 
    }
}
