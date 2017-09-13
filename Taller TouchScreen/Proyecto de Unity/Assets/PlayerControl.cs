using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour {
	public Text _label;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//detactamos si al menos hay un dedo en pantalla
		if (Input.touches.Length > 0) {
			//obtenemso el primer dedo en la pantalla
			//la informacion de cada dedo se guarda en un tipo de variable llamado Touch
			Touch dedo = Input.GetTouch (0);
			Vector3 pos = Camera.main.ScreenToWorldPoint (dedo.position);
			Debug.Log ("position:" + pos);
			pos.z = 0;
			transform.position = pos;

			//la variable Touch esta en diferentes fases dependiendo
			//de en que momento tocó o soltó la pantalla

			//si estas tocando la pantalla y moviendo el dedo
			//cambiamos el cubo a verde
			if (dedo.phase == TouchPhase.Moved) {
				GetComponent<Renderer> ().material.color = Color.green;
			}
			//si estas tocando la pantalla con el dedo quieto
			//pintamos el cubo de rojo
			else if (dedo.phase == TouchPhase.Stationary) {
				GetComponent<Renderer> ().material.color = Color.red;
			}
				

			//El deltaPosition es el vector que se forma entre la posicion
			//actual del dedo con la posicion del frame anterior

			//examinando el vector que se forma...podemos detectar si el usuario
			//ha hecho swipe en una cierta direccion

			//el componente y del vector debe ser muy pequeño
			if (Mathf.Abs(dedo.deltaPosition.y) < 5) {
				//el componente X debe ser grande
				if (dedo.deltaPosition.x > 30) {
					_label.text = "SWIPE DERECHA";
				}
			}
			//repetimos el mismo proceso para swipe la izquierda
			if (Mathf.Abs(dedo.deltaPosition.y) < 5) {
				if (dedo.deltaPosition.x < -30) {
					_label.text = "SWIPE IZQUIERDA";
				}
			}
		}


	}
}
