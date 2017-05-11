using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    //Si la vida entre la vida màxima es 0.5, entonces tiene la mitad de la vida
    //sirve para los bosses cuando se quiere activar la fase 2 del boss al llegar a la mitad de la vida

    // Use this for initialization
    void Start()
    {

    }


    //Funcion para disminuir o aumentar vida
    public void ModificarVida(float modificador)
    {
        health = health - modificador;
        if (health < 0)
        {
            health = 0;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}