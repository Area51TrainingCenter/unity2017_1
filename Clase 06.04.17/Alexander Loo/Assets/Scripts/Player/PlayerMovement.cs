using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool direccion = true;
    public float speedx = 1f;
    public float speedy = 1f;
    int contador = 1;
    bool contadorColor = true;
    

    // Esta función se ejecuta UNA vez al inicio
    void Start () {
        Debug.Log("hola");
        //declaramos una variable del tipo int (número entero)
        //la variable se llama "numero"
        // y le asignamos el valor cero
        int numero = 6;
        //aqui hacemos la declaración y asignación de la variable por separado
        int numero2;
        numero2 = 78;
        //float es para números decimales
        //siempre que le das un valor a una variable float
        //se pone "f" al final del número
        float numeroDecimal = -5.6f;

        Debug.Log("numeroDecimal: "+numeroDecimal);

        //el tipo "bool" solo admite los valores true y false
        bool booleano = false;
        //el if o condicional sirve para que 
        //solo si el valor dentro de los paréntesis es 
        //verdadero ... se ejecuta el código adentro
        if (booleano)
        {
            Debug.Log("entró el if");
        }//el "else" se ejecuta si la condición NO se cumple
        else {
            Debug.Log("NO entró el if");
        }
        //también se pueden hacer comparaciones de valores
        // == se usa para comparar si son iguales
        // <= para comparar si el valor es menor o igual a
        // >= para comparar si el valor es mayor o igual a
        // != se para preguntar si algo es diferente de 
        if (numero <= numero2)
        {

        }

        numero2 = numero2 + 1;


        // el operador % sirve para obtener el residuo despues
        // de dividir los dos números.
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
        //esta variable NO se destruye cuando termina la función Update
        contador = contador + 1;
        /*Debug.Log("contador:" + contador);

         if (contador % 2 == 0)
         {
             Debug.Log("es par");
         }else
         {
             Debug.Log("es impar");
         }*/
         //Para llamar a una función solo se pone el nombre de la función();
        Movimiento();
        CambiarColor();
    }

    void Movimiento()
    {
        /* //Input.GetMouseButtonDown(0) es click izquierdo
           //Input.GetMouseButtonDown(1) es click derecho
        bool mouseLongitud = Input.GetMouseButtonDown(0);
        bool mouseAltura = Input.GetMouseButtonDown(1);
        //si se presiona el botón del mouse la variable se vuelve true, si NO se presiona es false
        if (mouseLongitud)
        {
            Debug.Log("Presionaste el botón izquierdo del mouse");
            speedx = -speedx;
        }
        if (mouseAltura)
        {
            Debug.Log("Presionaste el botón derecho del mouse");
            speedy = -speedy;
        }*/
        bool KeyWPressed = Input.GetKey(KeyCode.W);
        //Mientras mantengas la tecla W presionada el booleano va ser verdadero
        bool KeySPressed = Input.GetKey(KeyCode.S);
        bool KeyAPressed = Input.GetKey(KeyCode.A);
        bool KeyDPressed = Input.GetKey(KeyCode.D);
        bool KeyShiftPressed = Input.GetKey(KeyCode.LeftShift);
        //las variables locales se destruyen y se crean de nuevo despues de una iteración
        float moveX = 0;
        float moveY = 0;
        
        if (KeyWPressed)
        {
            moveY = speedy;
        }
        if (KeySPressed)
        {
            moveY = -speedy;
        }
        if (KeyAPressed)
        {
            moveX = -speedx;
        }
        if (KeyDPressed)
        {
            moveX = speedx;
        }
        if (KeyShiftPressed)
        {
            moveX *= 10;
            moveY *= 10;
            
        }
        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
        //Time.deltaTime sirve para convertir la velocidad a algo mas humano(m/s)
    }
    void CambiarColor()
    {
        bool KeyShiftDown = Input.GetKeyDown(KeyCode.LeftShift);
        bool KeyShiftUp = Input.GetKeyUp(KeyCode.LeftShift);
        
        if (KeyShiftDown)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        if(KeyShiftUp)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (Time.timeScale < 1)
        {
            GetComponent<Renderer>().material.color = Color.green; 
        }
            /*
            if (contadorColor)
            {
                //código para cambiar de color
                GetComponent<Renderer>().material.color = Color.black;
                Debug.Log("Se presionó el botón");
                contadorColor = false;
                
            }else
            {
                GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("Volviste a presionar el botón");
                contadorColor = true;
            }*/
        
    }
   
}
