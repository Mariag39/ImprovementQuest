using UnityEngine;
using System.Collections;

public class TextosGabeN : MonoBehaviour {


	public GameObject texto1;
	public GameObject texto2;
	bool hablado = false;
	//public GameObject player;
	//public GameObject human;
	//public GameObject limit;

	private AudioSource audio;
	bool dentro;

	// Use this for initialization
	void Start () {
		
		texto1.SetActive (false);
		texto2.SetActive (false);

		audio = GetComponent<AudioSource>();


	}

	void Update () {
		
		if (GameManager.instance.nota) {
			if (dentro) {
				texto2.SetActive (true);
				hablado = true;
			}
		}
	}

	//Conversacion que te indica que hacer 
	void OnTriggerEnter2D(Collider2D collider){
		if (!hablado) {
			texto1.SetActive (true);
			dentro = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		texto1.SetActive (false);
		texto2.SetActive (false);

		dentro = false;
	}
}