using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFuera : MonoBehaviour
{
    public float magnitude = 20.0f; 
    private GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 direcciones = (player.transform.position.normalized - transform.position.normalized) * -1;
            rb.AddForce(direcciones * magnitude);
        }
    }
}
