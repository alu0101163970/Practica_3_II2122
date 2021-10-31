using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject referencia;
    public Vector3 offset = new Vector3(0.0f, 6.0f, -8.0f);
    private Transform target;
    public float sensibility = 5.0f;
    [Range (0, 1)] public float lerpValue = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        referencia = GameObject.Find("Referencia");
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;   
        transform.LookAt(target);

        Vector3 copiaRotacion= new Vector3(0, transform.eulerAngles.y, 0);
        referencia.transform.eulerAngles = copiaRotacion;
    }

}
