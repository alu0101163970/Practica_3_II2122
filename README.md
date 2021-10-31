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

![Imagen](https://drive.google.com/uc?export=view&id=1vhZTqvbe2MxUTSLRLtsljMe0ZPqcXxvd)  

+ Actualmente

![Imagen](https://drive.google.com/uc?export=view&id=1vhZTqvbe2MxUTSLRLtsljMe0ZPqcXxvd)  

Ver referencia a [Práctica 2 (Anterior)](https://github.com/alu0101163970/Practica_2_II2122.git) para consultar y comparar los cambios.

<div name="id2" />

## 2. Apartados Práctica 3

### Modificar la escena de la práctica anterior con los siguientes comportamientos:
+ Cuando el jugador colisiona con un objeto de tipo B, el objeto A mostrará un texto en una UI de Unity. Cuando toca el objeto A se incrementará la fuerza del objeto B.  


+ Cuando el jugador se aproxima a los cilindros de tipo A, los cilindros de tipo B cambian su color y las esferas se orientan hacia un objetivo ubicado en la escena con ese propósito. Consultar información de la clase Vector3: LookAt, RotateTowards, ...  


+ Implementar un controlador que mueva el objeto con wasd  


+ Buscar información de Debug.DrawRay y utilízala para depuración.  

