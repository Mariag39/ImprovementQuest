using UnityEngine;
using System.Collections;

public class GroundcheckDragon : MonoBehaviour {

	private Boss Dragon;

	void Start(){
		Dragon = gameObject.GetComponentInParent<Boss>();
	}

	void OnTriggerEnter2D (Collider2D col){
		Dragon.grounded = true;
	}

	void OnTriggerStay2D (Collider2D col){
		Dragon.grounded = true;
	}

	void OnTriggerExit2D (Collider2D col){
		Dragon.grounded = false;
	}
}
