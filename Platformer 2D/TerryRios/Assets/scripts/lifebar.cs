using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importar cosas que no estan por defecto
using UnityEngine.UI;

public class lifebar : MonoBehaviour {

	public health _healthscript;
	private Image _Image;


	// Use this for initialization
	void Start () 
	{
		_Image = GetComponent<Image> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		_Image.fillAmount = _healthscript.Health / _healthscript.maxHealth;
		
	}
}
