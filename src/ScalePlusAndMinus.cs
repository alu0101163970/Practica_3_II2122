using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScalePlusAndMinus : MonoBehaviour
{
    GameObject player;
    GameObject[] esferas;
    public float distance = 2f;
    public float aumento = 2f;
    public Vector3 scaleMax = new Vector3(5, 5, 5);
    public Vector3 scaleMin = new Vector3(1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        esferas = GameObject.FindGameObjectsWithTag("Esfera");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float aumentoRelativo = aumento * Time.deltaTime;
        Vector3 aumentoVector = new Vector3 (aumentoRelativo, aumentoRelativo, aumentoRelativo);
        if((transform.localScale.x < scaleMax.x)&&(transform.localScale.y < scaleMax.y)&&(transform.localScale.z < scaleMax.z))
        {
            float distanceBetweenAtoB = Vector3.Distance(player.transform.position, transform.position );
            if(distanceBetweenAtoB <= distance)
            {
                Vector3 tmp = transform.localScale + aumentoVector;
                transform.localScale = tmp;
            }

        }
        if((transform.localScale.x > scaleMin.x)&&(transform.localScale.y > scaleMin.y)&&(transform.localScale.z > scaleMin.z))
        {
            for (int i = 0; i < esferas.Length; i++)
            {
                float distanceBetweenAtoB = Vector3.Distance(esferas[i].transform.position, transform.position );
                if((transform.localScale.x > scaleMin.x)&&(transform.localScale.y > scaleMin.y)&&(transform.localScale.z > scaleMin.z))
                {
                    if(distanceBetweenAtoB <= distance)
                    {
                        Vector3 tmp = transform.localScale - aumentoVector;
                        transform.localScale = tmp;
                    }
                }
            }
        }
    }   
}
