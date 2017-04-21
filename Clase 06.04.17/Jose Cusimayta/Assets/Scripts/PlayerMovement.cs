using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.01f;
    public float speedX = 4f;
    public float speedY = 4f;
    public bool PressE = true;
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0F;
    public Renderer rend;
    /*public bool direccion = true;
    int contador = 1;*/

    // Esta funcion se ejecuta UNA vez al inicio
    void Start()
    {
        #region Clase 1
        /*
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
        */
        #endregion
    }

    // Update se ejecuta una vez cada frame
    void Update()
    {
        #region Clase 1
        //contador es una variable global
        //esta variable NO se destruye cuando termina la funcion Update
        /*
        contador = contador + 1;

        Debug.Log("contador:" + contador);

        if (contador % 2 == 0)
        {
            Debug.Log("es par");
        }
        else
        {
            Debug.Log("es impar");
        }
        */
        #endregion

        #region Clase 2
        //rend = GetComponent<Renderer>();
        //Movimiento();
        //CambiarColor();
        #endregion
        ///àl presionar  E se duplica la velocidad
        
        
        #region Clase 3
        
        //copia solo esta seccion
        MovimientoContinuo();
        ColorEstado();
        //hasta aca
        //pausa el juego, dale clic al cubo, y cambiale la velocidad, 
        #endregion

        #region movimiendo wasd
        /*
        //Direccionales para el cubo
        if (Input.GetKey(KeyCode.D))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, speed, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-speed, 0, 0);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -speed, 0);
        if (Input.GetKey(KeyCode.Space))
            transform.Rotate(1, 1, 1);
       */
        #endregion
    }

    #region Clase 2
    void Movimiento()
    {
        //Si el boton izquierdo del mouse esta presioado (0: izq, 1: der, 2: centro)
        //Debug.Log("Presionando el botón izquierdo del mouse");
        
        bool LeftPressed = Input.GetMouseButtonDown(0);
        if (LeftPressed)
            speedX *= -1;


        bool RightPressed = Input.GetMouseButtonDown(1);
        if (RightPressed)
            speedY *= -1;
        
        transform.Translate(speedX*Time.deltaTime, speedY * Time.deltaTime, 0);
        
        //transform.Translate(speedX, speedY, 0);
        //Para manejar metros por segundo m/s se multiplica la velocidad por "Time.deltaTime"
        

    }

    void CambiarColor()
    {
        bool KeyPressedE = Input.GetKeyDown(KeyCode.E);

        if (KeyPressedE && PressE)
        {
            Debug.Log("Mensaje A");
            PressE = false;
            GetComponent<Renderer>().material.color = Color.red;
            //float lerp = Mathf.PingPong(Time.time, duration) / duration;
            //rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
            //rend.material.color = Color.red;
        }
        else if (KeyPressedE && !PressE)
        {
            Debug.Log("Mensaje B");
            GetComponent<Renderer>().material.color = Color.green;
            PressE = true;

        }


    }
    #endregion

    #region Clase 3
    void MovimientoContinuo()
    {
        //las variables 
        float moveX = 0, moveY = 0;

        //Las variables para detectar si la tecla està presionada
        bool KeyWPressed = Input.GetKey(KeyCode.W);
        bool KeyDPressed = Input.GetKey(KeyCode.D);
        bool KeyAPressed = Input.GetKey(KeyCode.A);
        bool KeySPressed = Input.GetKey(KeyCode.S);
        //Variable para Acelerar
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        
        //Si la tecla està presionada, generar un movimiento continuo hacia la derecha, izquierda, arriba y abajo
        if (KeyWPressed)
        {
            moveY = speedY;
        }
        if (KeyDPressed)
        {
            moveX = speedX;
        }
        if (KeyAPressed)
        {
            moveX = -speedX;
        }
        if (KeySPressed)
        {
            moveY = -speedY;
        }
        //Acelerar
        if (shiftPressed)
        {
            moveX = moveX * 2;
            moveY = moveY * 2;            
        }
        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);

    }

    void ColorEstado()
    {
        //Cambia color al acelerar
        //Al presionar Shift
        bool shiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        //Al soltar shift
        bool shiftUP = Input.GetKeyUp(KeyCode.LeftShift);
        if (Time.timeScale < 1)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if (shiftPressed)
            {
                //Cambiar a color Azul
                GetComponent<Renderer>().material.color = Color.blue;
            }
            if (shiftUP)
            {
                //Cambiar a color Rojo
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    #endregion

    
}