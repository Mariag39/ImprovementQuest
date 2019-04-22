using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour {

	private Player player;
	private Player2 player2;

	void Start(){
		player = FindObjectOfType<Player> ();
		player2 = FindObjectOfType<Player2> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player2" || col.tag == "grounded"){
			GameManager.instance.PierdeCorazones ();
			player2.dañado = true;	

		}
		if (col.tag == "Player") {
			player.dañado = true;
			GameManager.instance.PierdeCorazones ();
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player2" || col.tag == "grounded") {
			GameManager.instance.PierdeCorazones ();
			player2.dañado = true;	

		}
		if (col.tag == "Player") {
			player.dañado = true;
			GameManager.instance.PierdeCorazones ();
		}
	}
 }
