using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public float frecuencia = 2;
    public GameObject[] balas;
    //Esta variable nos da acceso al transform del objeto vacío
    //public Transform _spawn;
    public Transform[] _spawns;
    public GameObject explosionMuerte;
    /*Al tratarse de componentes(GetComponent) es mejor asignarlo a una variable fuera del Update() porque al usarlo dentro del update
    se demora en buscarlo*/
    Health healthScript;
    Renderer _renderer;
    float previousHealth;

    void Start () {
        //InvokeRepeating("nombre de funcion a llamar",tiempo de espera para iniciar, frecuencia)
        InvokeRepeating("Disparo", 0, frecuencia);
        //existe variables de valor y referenciales...
        /*GetComponent es una variable referencial y se necesita que el valor cambie, por eso usar...
        GetComponent<Health>().health en una variable esta mal...*/
        healthScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previousHealth = healthScript.health;
    }
	
	
	void Update () {
        float enemigoHealth = healthScript.health;
        if (enemigoHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
        if(previousHealth != healthScript.health)
        {
            _renderer.material.color = Color.red;
            Invoke("CambiarColor", 0.1f);
        }
        //Actualizamos el valor de la variable a la vida actual 
        previousHealth = healthScript.health;

    }

    void Disparo()
    {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(proyectil, _spawn.position, _spawn.rotation);

        for (int i=0; i < _spawns.Length; i++)
        {
            for (int j = 0; j < balas.Length; j++)
            {
                Instantiate(balas[j], _spawns[i].position, _spawns[i].rotation);
            }
            
        }
    }
    void CambiarColor()
    {
        _renderer.material.color = Color.black;
    }
    
    
}
