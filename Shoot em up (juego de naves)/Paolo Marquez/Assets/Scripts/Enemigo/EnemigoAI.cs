using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    public GameObject _prefab, _explosionmuerte;
    public GameObject[] balasEnemigo;

    //esta variable nos da acceso al componente Transform del objeto vacio.
    //public Transform _spawn;
    public int sizeBalas = 4;
    public Transform[] _spawns;
    public float frecuenciaDisparo = 2;
    Vida vidaScript;
    Renderer _renderer;

    //esta variable nos da cuanta vida tenia el enemigo en el frame anterior
    float previousHealth;
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("restaurarColor", 1,1);
        //positionY = transform.position.y*Time.deltaTime;
        //permite invocar un objeto desde un metodo, desde un tiempo n en segundos, en un intervalo de n segundos
        //transform.Translate(0, 0, 0);
        vidaScript = GetComponent<Vida>();
        _renderer = GetComponent<Renderer>();
        previousHealth = vidaScript.vida;
        InvokeRepeating("Disparo",0, frecuenciaDisparo);
        //_spawns = new Transform[sizeBalas];
        //for(int i=0;i< _spawns.Length; i++)
        //{
        //    GameObject g = new GameObject();
        //    g.position
        //    _spawns[0] = new GameObject().transform.position;
        //}

    }
	
	// Update is called once per frame
	void Update () {
        float playerHealth = GetComponent<Vida>().vida;
        if (playerHealth <= 0)
        {
            Debug.Log("Se murio este gameObject: "+this.tag);
            Destroy(gameObject);
            Instantiate(_explosionmuerte, transform.position, transform.rotation);
        }

        //preguntamos si la vida en el frame anterior es diferente a la vida actual
        if (previousHealth != vidaScript.vida)
        {
            _renderer.material.color = Color.white;
            //Invoke("restaurarColor", 1);
        }
        //actualizamos el valor de la variable a la vida actual
        previousHealth = vidaScript.vida;

    }
    void restaurarColor()
    {
        //invoke ejecutara la funcion destruir cada 5 segundos
        Debug.Log("Regreso el color");
        _renderer.material.color = Color.red;
    }

    void Disparo()
    {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(_prefab, transform.position, rotacion);
        //var rota = _spawn.rotation;
        for (int i = 0; i < _spawns.Length; i++)
        {
            for(int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }
           
        }
       
    }

    
}
