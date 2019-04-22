using UnityEngine;
using System.Collections;

public class Recursos : MonoBehaviour {


	public GameObject obj;
	public GameObject oro;
	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}
		

	void OnCollisionEnter2D(Collision2D info){
		if (info.gameObject.tag == "Player") {
			audio.Play ();
			GameManager.instance.lingote = true;
			Destroy (obj);
	
			if (GameManager.instance.lingote = true)
				oro.SetActive (true);
		}
		if (info.gameObject.tag == "Player2") {
			GameManager.instance.nota = true;


			if (GameManager.instance.nota = true)
				oro.SetActive (true);
		}
	}

	void OnCollisionExit2D (Collision2D info){
		if (info.gameObject.tag == "Player2") {
			Destroy (obj);

		}
	}



}

