using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public Player player;
	public Player2 player2;
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Player" )
		player.onLadder = true;
		else if (other.tag == "Player2") 	
		player2.onLadder = true;
		
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.name == "Player" )
			player.onLadder = false;
		else if (other.tag == "Player2") 	
			player2.onLadder = false;
		
	}

}
