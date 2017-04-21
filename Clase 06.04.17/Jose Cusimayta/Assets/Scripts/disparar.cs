using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {
    public GameObject _prefab;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _Disparar();
    }

    void _Disparar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_prefab, transform.position, Quaternion.identity);            
        }
    }
}
