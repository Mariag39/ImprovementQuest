using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

	bool climb;

	public float climbpower;

	public Player2 player2;

	void Start () {
		player2 = FindObjectOfType<Player2> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Jump") && climb) {
			player2.climb (climbpower);
		}	
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Wall") {
			climb = true;
		}
	}

	void OnCollisionExit2D (Collision2D other){
		if (other.gameObject.tag == "Wall") {
			climb = false;
		}
	}

}
