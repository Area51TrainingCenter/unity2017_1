using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
public class FacebookUIManager : MonoBehaviour {
	public Text _debugText;
	// Use this for initialization
	void Start () {
		//inicializamos la conexión a facebook
		FB.Init (OnFBInit, null, null);
	}

	void OnFBInit(){
		//FB.IsInitialized es un booleano que nos dice si 
		//estamos conectados o no
		if (FB.IsInitialized) {
			Debug.Log ("connection success");
		}else{
			Debug.Log ("connection failed");
		}
	}
	
	public void LoginFB(){
		//Un List es un tipo de estructura similar a un arreglo
		//dentro de el <> se colocan el tipo de variable que contendrá el List
		List<string> permissions = new List<string> ();
		//la funcion Add añade un elemento nuevo a la lista
		permissions.Add ("public_profile");
		permissions.Add ("email");
		permissions.Add ("user_friends");
		FB.LogInWithReadPermissions (permissions, OnLoginFB);
	}

	void OnLoginFB(ILoginResult result){
		Debug.Log (result.RawResult);
		_debugText.text = result.RawResult;

	}

	public void ShareFB(){
		System.Uri URL = new System.Uri ("http://colorfulthegame.com");
		FB.ShareLink (URL, "Prueba Colorful", "Descripcion de prueba", null, null);
	}

	public void RequestFB(){
		FB.AppRequest ("Prueba este juego muy chevere", null, null, null, null, null, "Colorful es xvr", null);
		//FB.Mobile.AppInvite(
	}
}
