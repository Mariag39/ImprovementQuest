using UnityEngine;
using System.Collections;

public class MechanicsManager : MonoBehaviour {

	private Player player;

	public GameObject espada;

	bool MovLeft, Ladder, Jump, Jump2, Sword;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (MovLeft){
			player.MovLeft = true;
		}
		if (Ladder){
			player.Ladder = true;
		}
		if (Jump){
			player.Jump = true;
		}
		if (Jump2){
			player.Jump2 = true;
		}
		if (Sword){
			player.Sword = true;
			espada.SetActive (true);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "profesoroak") {
			MovLeft = true;
		}
		if (other.name == "donkeykong") {
			Ladder = true;
		}
		if (other.name == "monigote") {
			Jump = true;
		}
		if (other.name == "mario") {
			Jump2 = true;
		}
		if (other.name == "link") {
			Sword = true;
		}

}
}
