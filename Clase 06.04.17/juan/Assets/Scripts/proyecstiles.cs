using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyecstiles : MonoBehaviour {
    public float speed = 1000.10f;
    public GameObject _explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        {


        }
	}
}
