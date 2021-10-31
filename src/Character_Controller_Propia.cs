using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_Propia : MonoBehaviour
{
    public GameObject referencia;
    public float speed = 10.0f;
    public float rotateSpeed = 300.0f;
    GameObject player;
    public bool WASD = true;
    int puntuacion = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        referencia = GameObject.Find("Referencia");
    }

    // Update is called once per frame
    void Update()
    {
        Transform tf = player.GetComponent<Transform>();
        if (WASD){
            if (Input.GetKey(KeyCode.W))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.S))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.D))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
            }
        }
        else 
        {
            if (Input.GetKey("up"))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("left"))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("down"))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("right"))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
            }
        }

        transform.rotation = referencia.transform.rotation;
    }

    void OnCollisionExit(Collision other)
    {
        if ((other.collider.tag == "Cilindro Punto") || (other.collider.tag =="Tipo A") || (other.collider.tag =="Alejado")){
            puntuacion++;
            Debug.Log("Puntuación: " + puntuacion);
        }
    }
}
