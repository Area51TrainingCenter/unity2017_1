using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToHost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Esto te permite abrir en tu navegador una URL en especifico
		//Application.OpenURL("https://www.google.com.pe/");

		//iniciamos una corutina. Las corutinas se ejecutan en paralelo al flujo
		//principal de unity
		StartCoroutine (Connect ());
	}

	IEnumerator Connect(){
		Debug.Log ("hola");
		//WWW se usa para hacer solicitudes web a una URL en especifico
		//para mandar parametros se coloca al final de la URL  ?[nombreDeVariable]=[valor de variable]
		//en este caso creamos una variable llamada "nombreUsuario" y le damos el valor "hitoshi"
		WWW url = new WWW ("http://localhost:81/tallerunity/conectarDB.php?nombreUsuario=hitoshi");
		//esperamos que la solicitud web termine
		yield return url;
	

		//puedes crear pausas en segundos dentro de una corutina
	//	yield return new WaitForSeconds (2.0f);
		Debug.Log ("chau");
		//url.text te bota el resultado de la solicitud web
		Debug.Log (url.text);
	}
}
