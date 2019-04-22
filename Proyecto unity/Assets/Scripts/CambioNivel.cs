using UnityEngine;
using System.Collections;

public class CambioNivel : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D info){
		if (info.gameObject.tag == "Player2")
			Application.LoadLevel (Application.loadedLevel + 1);
		
	}
}
