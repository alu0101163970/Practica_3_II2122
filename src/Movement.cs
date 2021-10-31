using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
        }
    
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.collider.gameObject.name);
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.collider.gameObject.name);
    }
}
