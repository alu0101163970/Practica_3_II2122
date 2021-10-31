using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Miedo : MonoBehaviour
{
    public float distance = 3.0f; 
    public float speed = 100.0f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBetweenAtoB = Vector3.Distance(player.transform.position, transform.position );
        Vector3 direcciones = player.transform.position.normalized - transform.position.normalized;
        if(distanceBetweenAtoB <= distance)
        {
            direcciones.y = 0;
            transform.Translate(direcciones * Time.deltaTime * speed * -1, Space.World);
        }
    }
}
