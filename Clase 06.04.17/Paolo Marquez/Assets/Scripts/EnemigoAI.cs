using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public float positionY=5;
    public GameObject _prefab;
    
    // Use this for initialization
    void Start () {
        //positionY = transform.position.y*Time.deltaTime;
        //permite invocar un objeto desde un metodo, desde un tiempo n en segundos, en un intervalo de n segundos
        //transform.Translate(0, 0, 0);
        InvokeRepeating("Disparo",0,1);
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (transform.position.y >=5.0f)
        {
            positionY = -positionY;

        }


        if (transform.position.y <=-5.0f)
        {
            positionY = -positionY;

        }

        transform.Translate(0, positionY * Time.deltaTime, 0);


        //if (transform.position.y < 10.0f)
        //{
        //    transform.Translate(transform.position.x * Time.deltaTime, -transform.position.y * Time.deltaTime, 0);

        //}
        //if (transform.position.y < -5.0f)
        //{
        //    transform.Translate(transform.position.x * Time.deltaTime, transform.position.y * Time.deltaTime, 0);

        //}
    }

    void Disparo()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0,180);
        Instantiate(_prefab, transform.position, rotacion);
    }

    
}
