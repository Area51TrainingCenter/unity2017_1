﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	public float speed = 5;

	void Update(){

		transform.Translate (-Vector3.right * speed * Time.deltaTime);
	}
}
