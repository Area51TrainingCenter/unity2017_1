using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool direccion = true;
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    int contador = 1;



    // Esta funcion se ejecuta UNA vez al inicio
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("hola");
        //declaramos una variable del tipo int (numero entero)
        //la variable se llama "numero"
        // y le asignamos el valor cero
        int numero = 6;
        //aqui hacemos la declaracion y asignacion de la variable por separado
        int numero2;
        numero2 = 78;
        //float es para numeros decimales
        //siempre que le das un valor a una variable float
        //se pone "f" al final del numero
        float numeroDecimal = -5.6f;

        Debug.Log("numeroDecimal: " + numeroDecimal);

        //el tipo "bool" solo admite los valores true y false
        bool booleano = false;
        //el if o condicional sirve para que 
        //solo si el valor dentro de los parentesis es 
        //verdadero ... se ejecuta el codigo adentro
        if (booleano)
        {
            Debug.Log("entrò el if");
        }//el "else" se ejecuta si la condicion NO se cumple
        else
        {
            Debug.Log("NO entrò el if");
        }
        //tambien se pueden hacer comparaciones de valores
        // == se usa para comparar si son iguales
        // <= para comparar si el valor es menor o igual a
        // >= para comparar si el valor es mayor o igual a
        // != se para preguntar si algo es diferente de 
        if (numero <= numero2)
        {

        }

        numero2 = numero2 + 1;


        // el operador % sirve para obtener el residuo despues
        // de dividir los dos numeros.
        int num1 = 5;
        int num2 = 2;
        int resultado = num1 % num2;
        //con esto preguntamos si la variable resultado es par
        if (resultado % 2 == 0)
        {

        }
    }

    // Update se ejecuta una vez cada frame
    void Update()
    {
        //contador es una variable global
        //esta variable NO se destruye cuando termina la funcion Update
        contador = contador + 1;

        //Debug.Log("contador:" + contador);

        //if (contador % 2 == 0)
        //{
        //    Debug.Log("es par");
        //}else
        //{
        //    Debug.Log("es impar");
        //}


        Movimiento();
        cambiarColor();


    }

    void Movimiento()
    {
        float moveX = 0;
        float moveY = 0;

        //movimiento WASD

        bool keyWPressed = Input.GetKey(KeyCode.W);
        if (keyWPressed)
        {
            moveY = speedY;
        }

        bool keyAPressed = Input.GetKey(KeyCode.A);
        if (keyAPressed)
        {
            moveX = -speedX;
        }

        bool keyDPressed = Input.GetKey(KeyCode.D);
        if (keyDPressed)
        {
            moveX = speedX;
        }

        bool keySPressed = Input.GetKey(KeyCode.S);
        if (keySPressed)
        {
            moveY = -speedY;

        }



        //al presionar E se duplicara la velocidad
        bool keyLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (keyLeftShiftPressed)
        {
            moveX *= 2;
            moveY *= 2;
        }

        //convierte la velocidad por frames a velocidad por segundo
        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
    }

    void cambiarColor()
    {

        //down y up seran verdaderos una vez por frame, getKey para mantenerse verdadero tiene que presionar


        if (Time.timeScale < 1)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            //GetComponent<Renderer>().material.color = Color.blue;

            bool keyLeftShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
            if (keyLeftShiftPressed)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }

            keyLeftShiftPressed = Input.GetKeyUp(KeyCode.LeftShift);

            if (keyLeftShiftPressed)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }



    }




}