using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
        public GameObject _prefab;
	// Use this for initialization
	void Start () {  
      
	}
	
	// Update is called once per frame
	void Update () {
        bool keyFPressed = Input.GetKeyDown(KeyCode.F);
        if (keyFPressed)
        {
            Instantiate(_prefab,transform.position,transform.rotation);
        }
    }
}
