using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToController2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player") 
        {
            Vector3 direcciones = (other.collider.gameObject.transform.position.normalized - transform.position.normalized) * -1;
            ControladorEscena.controlador.CollisionOnA(direcciones);
        }
    }
}
