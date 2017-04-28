using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {
    
    public GameObject _baladeenemigo;
    public float freedisparo = 1.0f;
    public float speedY = 1f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("disparo", 0,freedisparo);
	}

    // Update is called once per frame
    void Update() {

        if (transform.position.y > 2.5f)
        {
            speedY = -speedY;
        }
        if (transform.position.y <= -3.5f)
        {
            speedY = speedY;
        }
        transform.Translate(0, speedY * Time.deltaTime, 0);
    }
        void disparo()
         {
            Quaternion rotacion = Quaternion.Euler(0, 0, 180);
            Instantiate(_baladeenemigo, transform.position, transform.rotation);

        }



	}

