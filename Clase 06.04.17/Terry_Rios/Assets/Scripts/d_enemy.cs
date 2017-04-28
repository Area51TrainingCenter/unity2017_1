using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_enemy : MonoBehaviour {

    public GameObject _balaenemigo;
    public float frecuencia = 0.5f;
    public float speedy = 5;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Disparo", 0, frecuencia);

    }

    
    // Update is called once per frame
    void Update () {
        transform.Translate(0, speedy * Time.deltaTime, 0);

        if (transform.position.y >= 3.2f)
        {
            speedy = -speedy;
        }
        if (transform.position.y <= -3.5f)
        {
            speedy = -speedy;
       
        }

    }

    void Disparo()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        Instantiate(_balaenemigo, transform.position, rotacion);
    }
}
