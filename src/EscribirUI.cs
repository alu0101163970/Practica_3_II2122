using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EscribirUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Text_UI;
    private int contadorDeColisiones = 0;
    void Start()
    {
        ControladorEscena.controlador.colisionB += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        contadorDeColisiones++;
        Text_UI.text = $"Has colisionado con el Objeto B {contadorDeColisiones} veces";
    }

}
