using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    bool direccion = true;
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    bool botomCambio = true;
    int contador = 1;

    public GameObject explosionMuerte;


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

        //aquí llamamos a nuestras funciones
        //para llamar a la funcion solo se pone el 
        // nombre de la funcion y abres y cierras parentesis
        Movimiento();
        CambiarColor();


        float playerHealth = GetComponent<Health>().health;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
    }

    //aquí creamos nuestra funcion llamada Movimiento
    void Movimiento() {

        float moveX = 0;
        float moveY = 0;
        //arriba
        bool keyWPressed = Input.GetKey(KeyCode.W);
        if (keyWPressed)
        {
            moveY = speedY;
        }
        //abajo
        bool keySPressed = Input.GetKey(KeyCode.S);
        if (keySPressed)
        {
            moveY = -speedY;
        }
        //izquierda
        bool keyAPressed = Input.GetKey(KeyCode.A);
        if (keyAPressed)
        {
            moveX = -speedX;
        }
        //derecha
        bool keyDPressed = Input.GetKey(KeyCode.D);
        if (keyDPressed)
        {
            moveX = speedX;
        }

        //detectamos que hemos presionado la tecla Shift
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        if (shiftPressed)
        {
            moveX = moveX * 2;
            moveY = moveY * 2;
        }

        //Time.deltaTime es un float convierte la velocidad a que
        //sea por segundo y ya no por frame
        transform.Translate(moveX*Time.deltaTime, moveY*Time.deltaTime, 0);
    }

    void CambiarColor() {

        bool shiftDown = Input.GetKeyDown(KeyCode.LeftShift);
        if (shiftDown)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        //GetKeyUp detecta el instante en el que sueltas la tecla shift
        bool shiftUp = Input.GetKeyUp(KeyCode.LeftShift);
        if (shiftUp) {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (Time.timeScale < 1)
        {
            GetComponent<Renderer>().material.color = Color.green;

        }



        /*
        //detectamos que hemos presionado la tecla E
        bool keyEPressed = Input.GetKeyDown(KeyCode.E);
        if (keyEPressed)
        {

            //usamos una variable bool para saber si debemos
            //cambiar a color rojo o blanco
            //cada vez que cambiamos de color
            //cambiamos  el valor del booleano
            if (botomCambio)
            {
                //esta linea cambia el color del cubo a rojo
                GetComponent<Renderer>().material.color = Color.red;
                botomCambio = false;
            }
            else {
                //esta linea cambia el color del cubo a rojo
                GetComponent<Renderer>().material.color = Color.blue;
                botomCambio = true;
            }
        }
        */

    }

}
