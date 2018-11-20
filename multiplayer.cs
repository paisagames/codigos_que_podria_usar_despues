using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class sds : NetworkBehaviour {

//CREAR UN GAMEOBJECT EXTERNO CON LA PROPIEDAD "Network Manager" y "Network Manager HUD", 
//en el primer codigo ("Network Manager") poner en el "Player Prefab" el Gameobjet que tiene este codigo
//AL OBJETO QUE VAYAS A AGREGARLE ESTE SCRIPT AGREGARLE LA PROPIEDAD "Network Identity" y "Network Transform" (Network send rate 9)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(!isLocalPlayer){
			return;
			}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		
		
		
	}
}
