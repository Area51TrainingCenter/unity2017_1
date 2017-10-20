using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos las librerias del editor
using UnityEditor;
[CustomEditor(typeof(CharacterInfo))]
//el script DEBE heredar de Editor
public class CharacterInfoEditor : Editor {
	private SerializedProperty _vidas;
	private SerializedProperty _HP;
	private SerializedProperty _useWeapons;

	private SerializedProperty _weapon;
	private SerializedProperty _secondaryWeapon;
	void OnEnable(){
		_vidas = serializedObject.FindProperty ("vidas");
		_HP = serializedObject.FindProperty("HP");
		_useWeapons = serializedObject.FindProperty("useWeapons");
		_weapon = serializedObject.FindProperty("weapon");
		_secondaryWeapon = serializedObject.FindProperty("secondaryWeapon");

	}

	//OnInspectorGUI define cómo es que se mostraran las variables del script
	//CharacterInfo en el editor
	public override void OnInspectorGUI(){
		
		GUIStyle titleStyle = new GUIStyle ();
		titleStyle.fontSize = 16;
		titleStyle.fontStyle = FontStyle.Bold;
		titleStyle.normal.textColor = Color.blue;
	
		EditorGUILayout.LabelField ("Informacion del personaje",titleStyle);
		EditorGUILayout.Space ();

		GUIStyle sectionStyle = new GUIStyle ();
		sectionStyle.fontSize = 12;
		sectionStyle.fontStyle = FontStyle.Bold;
		sectionStyle.normal.textColor = Color.black;

		EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.LabelField ("Salud del personaje",sectionStyle);


		EditorGUILayout.PropertyField (_vidas, new GUIContent ("Numero de vidas"));
			_vidas.intValue = Mathf.Clamp (_vidas.intValue, 1, 99);
			

			EditorGUILayout.PropertyField (_HP, new GUIContent ("Puntos de golpe"));
		EditorGUILayout.EndVertical ();
		EditorGUILayout.EndFadeGroup ();

		EditorGUILayout.BeginVertical ("Box");
			EditorGUILayout.LabelField ("Armas del personaje",sectionStyle);
			EditorGUILayout.PropertyField (_useWeapons, new GUIContent ("¿El personaje usará armas?"));
			if (_useWeapons.boolValue == true) {
				EditorGUILayout.PropertyField (_weapon, new GUIContent ("Arma principal"));
				if (_weapon.objectReferenceValue == null) {
					EditorGUILayout.HelpBox ("No has asignado un arma principal", MessageType.Error);
				}
				EditorGUILayout.PropertyField (_secondaryWeapon, new GUIContent ("Arma secundaria"));
			}
			
		EditorGUILayout.EndVertical ();

		//esto muestra las variables de la forma tradicional de Unity
		//DrawDefaultInspector ();

		GUIStyle buttonStyle = new GUIStyle (EditorStyles.miniButton);
		buttonStyle.fixedHeight = 60;
		buttonStyle.fontSize = 16;

		if (GUILayout.Button ("RESET",buttonStyle)) {
			_vidas.intValue = 3;
			_HP.intValue = 100;
			_weapon.objectReferenceValue = null;
			_secondaryWeapon.objectReferenceValue = null;
		}

		serializedObject.ApplyModifiedProperties ();
	}

}
