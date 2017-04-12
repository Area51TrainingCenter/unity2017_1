using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool direccion = true;
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    public bool botonECambio = true;
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
            Debug.Log("entró el if");
        }//el "else" se ejecuta si la condicion NO se cumple
        else {
            Debug.Log("NO entró el if");
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

        //aquí llamamos a nuestras funciones
        //para llamar a la función solo se pone el 
        Movimiento();
        CambiarColor();
    }

    void Movimiento (){
        bool leftMousePressed = Input.GetMouseButtonDown(0);

        if (leftMousePressed)
        {
            Debug.Log("Presionaste el botón del mouse");
            speedX = speedX * -1;
        }

        bool rightMousePressed2 = Input.GetMouseButtonDown(1);

        if (rightMousePressed2)
        {
            speedY = speedY * -1;
        }

        transform.Translate(speedX*Time.deltaTime, speedY*Time.deltaTime, 0);
    }

    void CambiarColor()
    {
        
        bool keyEPressed = Input.GetKeyDown(KeyCode.E);


        if (keyEPressed)
        {            
            if (botonECambio)
            {
                Debug.Log("No está.");
                GetComponent<Renderer>().material.color = Color.blue;
                botonECambio = false;
            }
            else
            {
                Debug.Log("Sí está.");
                GetComponent<Renderer>().material.color = Color.green;
                botonECambio = true;
            }
        }
       
    }

}
