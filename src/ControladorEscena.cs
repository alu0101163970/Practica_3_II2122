using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControladorEscena : MonoBehaviour
{
    public delegate void colisionConA (Vector3 direcciones);
    public delegate void colisionConB ();
    public delegate void CloseToCiliderTypeA ();
    public event colisionConA colisionA;
    public event colisionConB colisionB;
    public event CloseToCiliderTypeA CloseToCA;
    public static ControladorEscena controlador;

    private bool bCollided = false;
    private bool aCollided = false;
    private Vector3 direccionEmpuje;
    private bool isClose = false;
    void Awake()
    {
        if(controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(this);
        }
        else if (controlador != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bCollided)
        {
            colisionB();
            bCollided = false;
        };

        if (aCollided)
        {
            colisionA(direccionEmpuje);
            aCollided = false;
        };
        if (isClose)
        {
            CloseToCA();
        }
    }

    public void CollisionOnA (Vector3 direcciones)
    {
        aCollided = true;
        direccionEmpuje = direcciones;
    }

    public void CollisionOnB ()
    {
        bCollided = true;
    }

    public void CloseToCilinderA(bool value)
    {
        isClose = value;
    }
}
