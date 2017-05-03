using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoAI : MonoBehaviour
{
    #region Variables
    public GameObject[] balaEnemigo;
    public Transform[] _spawns;
    public float frecDisparo = 1f;
    #endregion

    #region Funciones Nativas
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Disparo", 0, frecDisparo);
    }

    // Update is called once per frame
    void Update()
    {
        Morir();

    }
    #endregion

    #region Funciones
    void Disparo()
    {
        #region Comentarios
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala siempre se mueve en direccion a su
        //eje X local ... rotamos la bala
        //para que se vaya hacia la izquierda
        //Instantiate(balaEnemigo, transform.position, rotacion);
        //añt + 35 = #
        #endregion

        for (int i = 0; i < _spawns.Length; i++)
        {
            for (int j = 0; j < balaEnemigo.Length; j++) //Cambiado
            {
                Instantiate(balaEnemigo[j], _spawns[i].position, _spawns[i].rotation);  //Cambiado
            }
        }

    }
    void Morir()
    {
        float _health = GetComponent<Health>().health;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}