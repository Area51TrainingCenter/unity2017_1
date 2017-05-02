using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_enemy : MonoBehaviour {

    public GameObject _balaenemigo;
    public Transform _spawn;
    public float frecuencia = 0.5f;
    public Transform[] _spawns;
    

	// Use this for initialization
	void Start () {

        InvokeRepeating("Disparo", 0, frecuencia);

    }

    
    // Update is called once per frame
    void Update () {
       

    }

    void Disparo()
    {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(_balaenemigo, transform.position, rotacion);
        Instantiate(_balaenemigo, _spawn.position, _spawn.rotation);

        for(int i = 0;i < _spawns.Length; i++)
        {
            Instantiate(_balaenemigo, _spawns[i].position, _spawns[i].rotation);
        }

    }
}
