using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool direccion = true;
    public float speedX = 1f;
    public float speedY = 1f;
    int contador = 1;

    // Esta funcion se ejecuta UNA vez al inicio
    void Start() {
        // Debug.Log("hola");
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

        // Debug.Log("numeroDecimal: " + numeroDecimal);

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
    void Update() {
        //contador es una variable global
        //esta variable NO se destruye cuando termina la funcion Update
        contador = contador + 1;

        // Debug.Log("contador:" + contador);
        /*
        if (contador % 2 == 0)
        {
            Debug.Log("es par");
        } else
        {
            Debug.Log("es impar");
        }
        */

        Movimiento();
        CambiarColor();

    }

    void Movimiento()
    {
        /////////////////////////////////////////////////////
        /*
        bool mousePressedLeft = Input.GetMouseButtonDown(0);
        bool mousePressedRight = Input.GetMouseButtonDown(1);

        if (mousePressedLeft)  speedX *= -1;
        if (mousePressedRight) speedY *= -1;
        */
        /////////////////////////////////////////////////////

        float moveX = 0;
        float moveY = 0;

        // detectar teclas

            // ARRIBA
            bool keyPressedW = Input.GetKey(KeyCode.W);
            if (keyPressedW) moveY = speedY;
            // ABAJO
            bool keyPressedS = Input.GetKey(KeyCode.S);
            if (keyPressedS) moveY = -speedY;
            // IZQUIERDA
            bool keyPressedA = Input.GetKey(KeyCode.A);
            if (keyPressedA) moveX = -speedX;
            // DERECHA
            bool keyPressedD = Input.GetKey(KeyCode.D);
            if (keyPressedD) moveX = speedX;

        // detectar tecla SHIFT
        bool keyPressedLS = Input.GetKey(KeyCode.LeftShift);
        if ( keyPressedLS )
        {
            // duplicar la velocidad ( ojo: speed es una variable global )
            moveX = moveX * 3;
            moveY = moveY * 3;
        }

        transform.Translate(moveX*Time.deltaTime, moveY*Time.deltaTime, 0);
    }

    bool statusMSG = true;

    void CambiarColor()
    {
        // detectamos qyue hemos presionado tecla E
        /*
        bool keyPressedE = Input.GetKeyDown(KeyCode.E);
        if ( keyPressedE )
        {
            if (statusMSG)
            {
                GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("Color Rojo");
            } else {
                GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("Color Verde");
            }

            // cambiar
            statusMSG = !statusMSG;
        }
        */



        // ( nota: esto consume recurso constantemente  )
        // COLOR VERDE
        // GetComponent<Renderer>().material.color = Color.green;
        // detectar tecla SHIFT 
        /*
        bool keyPressedLS = Input.GetKey(KeyCode.LeftShift);
        if (keyPressedLS)
        {
            // COLOR ROJO
            GetComponent<Renderer>().material.color = Color.red;
        }
        */


        // ( nota: aqui mejoramos el consumo )
        bool shiftDown = Input.GetKeyDown(KeyCode.LeftShift);
        if ( shiftDown )
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        bool shiftUp = Input.GetKeyUp(KeyCode.LeftShift);
        if ( shiftUp )
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if ( Time.timeScale < 1 )
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }


    }

    public GameObject _morir;

    // esta funcion va detectar cualquier cosa que entre en su volumen
    // OJO: antes, debes ir a Unity y en
    // Componente "Box Collider"
    // activar check 'Is Trigger'
    void OnTriggerEnter(Collider other)
    {
        // other, representa el objeto que ha tocado este elemento ( Zona Lenta )
        Debug.Log(other.name);

        if (other.CompareTag("enemigo"))
        {
            Instantiate(_morir, transform.position, transform.rotation);
            Destroy(other.gameObject); // destruimos el objeto que toca ( cuadrado grande )
            Destroy(gameObject); // destruimos este objeto ( esta esfera )
        }

    }
}
