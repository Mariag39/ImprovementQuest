using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerEnter2D(Collider2D info){
		if (info.gameObject.tag == "espada") {
			Destroy (enemy);
		}
	}



}
