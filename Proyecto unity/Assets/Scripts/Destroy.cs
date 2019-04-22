using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public GameObject enemy;
	public bool dragon;
	public float timer;
	public float numgolpes = 0f;
	public bool fireball;
	void Update(){
		if (fireball)
			Destroy (enemy, timer);


	}
	void OnTriggerEnter2D (Collider2D info) {
		if (info.gameObject.tag == "espada") {
			if (dragon) {
				GameManager.instance.DañoDragon ();
		    	} else {
				numgolpes--;

				if (numgolpes <= 0) {
					GameObject.Destroy (enemy);
				}

			}	
		}
		if (fireball) {
			
			if (info.gameObject.tag == "Player2") {
				Destroy (enemy);
			}



		}
	
	}

}
