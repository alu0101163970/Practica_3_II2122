using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeColor : MonoBehaviour
{
    // Colours
     Color[] colors = { new Color(0,1,0,1), new Color(1,0,0,1), new Color(1,1,1,1), new Color(0,0,1,1),  new Color(1,1,0,1), new Color(0, 0, 0, 1)};
    // Start is called before the first frame update
    void Start()
    {
        ControladorEscena.controlador.CloseToCA += ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(0, 6); //for ints
        GetComponent<Renderer>().material.color = colors[rInt];
        
    }
}
