using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {
	public float speed;
	private Player2 player;
	public bool lvl2;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player2> ();
		rb2d = GetComponent<Rigidbody2D> ();

		}



	void Update () {
		if (lvl2) {
			transform.position += transform.right * speed * Time.deltaTime;

		} else {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime * speed);
		}
	}
	void OnTriggerEnter2D(Collider2D info){
		if (info.tag == "Player2") {
			GameManager.instance.PierdeCorazones ();

		}


	
	}
}
