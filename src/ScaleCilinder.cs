using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCilinder : MonoBehaviour
{
    [Range (0, 10)]public float aumento = 3f;
    private Rigidbody rb;
    public float forceMagnitude = 5.0f;
    public Vector3 scaleMax = new Vector3(10, 10, 10);
    private bool maxReached = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        { 
            Vector3 direcciones =(other.collider.transform.position.normalized - transform.position.normalized) * -1;
            rb.AddForce(direcciones * forceMagnitude);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.tag == "Player")
        { 
            float aumentoRelativo = aumento * Time.deltaTime;
            Vector3 aumentoVector = new Vector3 (aumentoRelativo, aumentoRelativo, aumentoRelativo);
            if(maxReached)
            {
                
            } 
            else 
            {
                Vector3 tmp = transform.localScale + aumentoVector;
                transform.localScale = tmp;
                if (scaleMax.x < transform.localScale.x)
                {
                    maxReached = true;
                }
            }
        }
    }

}
