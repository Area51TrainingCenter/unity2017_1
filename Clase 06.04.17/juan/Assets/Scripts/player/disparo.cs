using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour {
    public GameObject _prefab;
    public float freedisparo = 1.0f;
    // Use this for initialization
    void Start () {
        InvokeRepeating("disparo", 0, freedisparo);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) 
     //instantiate crea un clan del prefab que le damos
        Instantiate(_prefab, transform.position, transform.rotation);
    }
}
