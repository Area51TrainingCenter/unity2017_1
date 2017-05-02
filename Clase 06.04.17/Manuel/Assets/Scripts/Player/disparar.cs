using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    //esta variable nos sirve para recibir el prefab
    //del proyectil
    public GameObject _prefab;
    // Use this for initialization
    void Start()
    {
        /*Instantiate crea un clon del prefab que le damos
        Instantiate(_prefab);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate crea un clon del prefab que le damos
            Instantiate(_prefab,transform.position,transform.rotation);
        }
        


    }
}
    


