using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementarFuerza : MonoBehaviour
{
    private float magnitude = 1.0f; 
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ControladorEscena.controlador.colisionA += IncF;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncF(Vector3 direcciones)
    {
        magnitude = magnitude * 2;
        rb.AddForce(direcciones * magnitude);
    }
}
