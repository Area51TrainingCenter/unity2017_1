using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {
    int contador = 1;
    public bool direccion = true;
    public float speed = 10;

	// Use this for initialization
	void Start () {
        Debug.Log("hola");
        int numero = 2;
        int numero2 = 7;
        Debug.Log(numero2);
        float numerodecimal = 5.6f;
        Debug.Log(numero+numero2);
        Debug.Log("numerodecimal:"+numerodecimal);
        bool booleano = true;
        if (booleano)
        {
            Debug.Log("entro el if");
        }
        else
        {
            Debug.Log("no entro el if");
        }
        if (numero <= numero2)
        {

        }

	}
	
	// Update is called once per frame
	void Update () {
        contador = contador + 1;
        int num1 = 5;
        int num2 = 2;
        int resultado = num1 % num2;
        Debug.Log("contador:" + contador);
        if (contador % 2 == 0)
        {
            Debug.Log("par");
        }
        else
        {

            Debug.Log("impar");
        }
        
        transform.Translate(speed, 0, 0);
		
	}
}
