using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {
    //plantilla del proyectil
    public GameObject _prefab;

	// Use this for initialization
	void Start () {
        //crea un clon del prefab
        
		
	}
	
	// Update is called once per frame
	void Update () {

        bool keyfpressed = Input.GetKeyDown(KeyCode.F);

        if (keyfpressed)
        {
            Instantiate(_prefab,transform.position,transform.rotation);
        }

    }

    
}
