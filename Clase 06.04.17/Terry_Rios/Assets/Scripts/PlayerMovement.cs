using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool direccion = true;
    public float speedX = 5;
    public float speedY = 5;
    int contador = 1;

	// Esta funcion se ejecuta UNA vez al inicio
	void Start () {
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

        Debug.Log("numeroDecimal: "+numeroDecimal);

        //el tipo "bool" solo admite los valores true y false
        bool booleano = false;
        //el if o condicional sirve para que 
        //solo si el valor dentro de los parentesis es 
        //verdadero ... se ejecuta el codigo adentro
        if (booleano)
        {
            Debug.Log("entrò el if");
        }//el "else" se ejecuta si la condicion NO se cumple
        else {
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
    void Update () {
        //contador es una variable global
        //esta variable NO se destruye cuando termina la funcion Update
        contador = contador + 1;
        /*
        Debug.Log("contador:" + contador);

        if (contador % 2 == 0)
        {
            Debug.Log("es par");
        }else
        {
            Debug.Log("es impar");
        }
        */

        Movimiento();
        Cambiarcolor();

    }

    void Movimiento()
    {
        float moveX = 0;
        float moveY = 0;

        //W

        bool KeywPressed = Input.GetKey(KeyCode.W);

        if (KeywPressed)
        {
            moveY = speedY;
        }

        //S

        bool KeysPressed = Input.GetKey(KeyCode.S);

        if (KeysPressed)
        {
            moveY = -speedY;
        }

        //A

        bool KeyaPressed = Input.GetKey(KeyCode.A);

        if (KeyaPressed)
        {
            moveX = -speedX;
        }

        //D

        bool KeydPressed = Input.GetKey(KeyCode.D);

        if (KeydPressed)
        {
            moveX = speedX;
        }

        

        bool KeyshiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (KeyshiftPressed)
        {
            moveX = moveX * 2;
            moveY = moveY * 2;

        }

        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);

    }

    public bool tecla1 = true;

    void Cambiarcolor()    
    {
        //cambio de color con el shift

        bool KeyshiftDown = Input.GetKeyDown(KeyCode.LeftShift);

        if (KeyshiftDown)
        {
            Debug.Log(GetComponent<Renderer>().material.color = Color.red);
        }

        bool Keyshiftup = Input.GetKeyUp(KeyCode.LeftShift);

        if (Keyshiftup)
        {
            Debug.Log(GetComponent<Renderer>().material.color = Color.blue);
        }


        if (Time.timeScale == 0.3f)
        {
            Debug.Log(GetComponent<Renderer>().material.color = Color.green);
        }
        

      
       
        


        bool KeyPressed = Input.GetKey(KeyCode.E);
        if (KeyPressed)
        {
            
        
            if (tecla1)
            {
                Debug.Log(GetComponent<Renderer>().material.color = Color.red);
                tecla1 = false;
            }
            else
            {
                Debug.Log(GetComponent<Renderer>().material.color = Color.blue);
                tecla1 = true;
            }

            
        }
       
    }
    

    
}
