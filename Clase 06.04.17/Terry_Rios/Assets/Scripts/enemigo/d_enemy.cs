using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_enemy : MonoBehaviour {

    public GameObject[] _balasenemigo;
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
        

        for(int i = 0;i < _spawns.Length; i++)
        {
            for (int J = 0; J < _balasenemigo.Length; J++)
            {
                Instantiate(_balasenemigo[J], _spawns[i].position, _spawns[i].rotation);
            }
           
        }

    }
}
