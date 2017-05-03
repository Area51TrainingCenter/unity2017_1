using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    
    public GameObject _prefab;
    public GameObject[] balasEnemigo;
    //esta variable nos da acceso al componente Transform del objeto vacio.
    //public Transform _spawn;
    public int sizeBalas=4;
    public Transform[] _spawns;
    public float frecuenciaDisparo = 2;
    
    // Use this for initialization
    void Start () {
        //positionY = transform.position.y*Time.deltaTime;
        //permite invocar un objeto desde un metodo, desde un tiempo n en segundos, en un intervalo de n segundos
        //transform.Translate(0, 0, 0);
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
