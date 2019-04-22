using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	public GameObject go;

	SpriteRenderer block;

	private BoxCollider2D col;
	private SpriteRenderer renderer;

	public float Destoy = 1.3f;
	public float RespawnDelay = 3f;

	public float des = -10;

	void Start (){
		des = -10;
		renderer = go.GetComponent<SpriteRenderer>();
		col = go.GetComponent<BoxCollider2D> ();
	}

	void Update () {
		des -= Time.deltaTime;

		if (des < 0) {
			go.transform.localScale = new Vector3 (0, 0, 0);
			col.isTrigger = true;
		}

		if (des < -3) {
			col.isTrigger = false;
			go.transform.localScale = new Vector3 (2.77f, 2.39f, 0);
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player2") {
			des = Destoy;
		}
	}
}
