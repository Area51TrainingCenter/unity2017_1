using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverX : MonoBehaviour {

    public float speed = 5;
	void Start () {
		
	}
	
	
	void Update () {
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
