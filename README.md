# Práctica 3 de Interfaces Inteligentes.

## **Autor**: Francisco Jesus Mendes Gomez.

## **Índice:**  

1. [**Estado Actual**](#id1)
2. [**Apartados Práctica 3**](#id2)   

<div name="id1" />

## 1. Estado actual.

Para esta práctica se ha continuado la el trabajo realizado en la práctica anterior, haciendo ligeras modificaciones en los scripts:  

+ `Character_Controller_Propia.cs` 
+ `Miedo.cs`
+ `Movement.cs`
+ `MoverFuera.cs`
+ `ScaleCilinder.cs`
+ `ScalePlusAndMinus.cs`

Y se ha añadido el script `FollowPlayer.cs` para que la cámara siga al jugador desde una perspectiva de tercera persona. Aparte de varios aspectos visuales.  
+ Anteriormente

![Imagen](./img/Practica2.gif)  

+ Actualmente

![Imagen](./img/Practica3Inicio.gif)  

Ver referencia a [Práctica 2 (Anterior)](https://github.com/alu0101163970/Practica_2_II2122.git) para consultar y comparar los cambios.

<div name="id2" />

## 2. Apartados Práctica 3

### Modificar la escena de la práctica anterior con los siguientes comportamientos:
+ Cuando el jugador colisiona con un objeto de tipo B, el objeto A mostrará un texto en una UI de Unity. Cuando toca el objeto A se incrementará la fuerza del objeto B.  

Para este apartado se ha creado un Controlador de las escena que se encuentra en el fichero `ControladorEscena.cs`. Para gestionar los delegados y los eventos cuando colisiona el jugador con el objeto A y con el objeto B. 
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControladorEscena : MonoBehaviour
{
    public delegate void colisionConA (Vector3 direcciones);
    public delegate void colisionConB ();
    public event colisionConA colisionA;
    public event colisionConB colisionB;
    public static ControladorEscena controlador;

    private bool bCollided = false;
    private bool aCollided = false;
    private Vector3 direccionEmpuje;
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
    private GameObject objetoB; 
    void Start()
    {
        objetoB = GameObject.Find("ObjetoTipoB");
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
}

```

También se han añadido los siguientes scripts para este propósito:

  + `SendMessageToGameControler.cs`: Para avisar al controlador que el jugador ha colisionado con el objeto B.
  + `EscribirUI.cs`: Hacer que el objeto A manipule el objeto UI text indicando cuantas vesces se ha colisionado con el objeto B.
  + `SendMessageToController2.cs`: Para avisar al controlador que el jugador ha colisionado con el objeto A.
  + `IncrementarFuerza.cs`: Para que el objeto B sea empujado a la dirección opuesta de la colision de A con el jugador y que a medida que estos colisionen más veces este empuje será más fuerte.  



Resultado:

![Imagen](./img/Practica31.gif)  

Aquí el objeto A es el cubo dorado y el objto B es la capsula dorada.  


+ Buscar información de Debug.DrawRay y utilízala para depuración.

Debug.DrawRay es una función que nos permite trazar rayos sobre el juego en ejecución para ayudarnos a la depuración. Por ejemplo nos permite trazar un raya para saber hacia donde esta mirando un objeto, como es el caso del apartado siguiente donde lo usaremos para visualizar como las esfera mira hacia el objeto que tienen que mirar.

+ Cuando el jugador se aproxima a los cilindros de tipo A, los cilindros de tipo B cambian su color y las esferas se orientan hacia un objetivo ubicado en la escena con ese propósito. Consultar información de la clase Vector3: LookAt, RotateTowards, ...  

Se ha modificado el fichero `ControladorEscena.cs` como vemos a continuación:  
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControladorEscena : MonoBehaviour
{
    public delegate void colisionConA (Vector3 direcciones);
    public delegate void colisionConB ();
    //Se ha añadido esto
    public delegate void CloseToCiliderTypeA ();

    public event colisionConA colisionA;
    public event colisionConB colisionB;
    //Se ha añadido esto
    public event CloseToCiliderTypeA CloseToCA;

    public static ControladorEscena controlador;

    private bool bCollided = false;
    private bool aCollided = false;
    private Vector3 direccionEmpuje;
    //Se ha añadido esto
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
        //Se ha añadido esto
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
    //Se ha añadido esto
    public void CloseToCilinderA(bool value)
    {
        isClose = value;
    }
}

``` 
Todo esto para añadir un evento que se acciona si el jugador se acerca a un cilidro tipo A el cual tiene los siguiente efectos:  

+ Los cilindros B cambian su color. Para ello se han creado los scripts `ComunicatePlayerIsClose.cs` que manda un mensaje al controlador de la escena indicando que el jugador se ha acercado a un cilindro de tipo A. Y el script `CambioDeColor.cs` para cambiar aleatoriamente el color de los cilindros tipo B cuando se active el evento.

+ Las esferas se orientan hacia un objetivo. El script `LookToCenterObject.cs` es el encargado de hacer que las esferas miren hacia el objeto llamado **ImanDeBolas** que es una capsula roja.

Resultado:

![Imagen](./img/Practica32.gif)

Aquí observamos el uso del `Debug.DrawRay` que son los rayos verdes que que trazan hacia donde miran las esferas y como al acercarnos a los cilindros tipo A que son de color dorado hacen que los tipo B cambien de color y como las esferas se orientan hacia la capsula de color rojo que es el objeto ImanDeBolas. 

+ Implementar un controlador que mueva el objeto con wasd  


