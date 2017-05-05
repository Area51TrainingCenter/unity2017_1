using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool direccion = true;
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    public GameObject explosionMuerte;
    int contador = 1;



    // Esta funcion se ejecuta UNA vez al inicio
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        
    }

    // Update se ejecuta una vez cada frame
    void Update()
    {
       
        Movimiento();
        cambiarColor();
        float playerHealth=GetComponent<Vida>().vida;
        if (playerHealth<=0)
        {
            Debug.Log("Se murio este gameObject");
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }

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