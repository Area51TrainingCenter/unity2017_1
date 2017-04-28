using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    // Script para disparar las balas del Player

    public GameObject _prefab;


	// Use this for initialization
	void Start () {
       
        

    }
	 
	// Update is called once per frame
	void Update () {
        // TECLA Z
        bool keySpacePressed = Input.GetKeyDown (KeyCode.Space);
        if (keySpacePressed)
        {
               // 
            Instantiate(_prefab,transform.position,transform.rotation);
        }
    }
}
