using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComunicatePlayerIsClose : MonoBehaviour
{
    private GameObject player;
    public float distance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBetWeenAtoPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceBetWeenAtoPlayer <= distance) 
        {
            ControladorEscena.controlador.CloseToCilinderA(true);
        }
        else 
        {
            ControladorEscena.controlador.CloseToCilinderA(false);
        }   
    }
}
