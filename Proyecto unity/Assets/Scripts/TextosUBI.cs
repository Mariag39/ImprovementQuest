using UnityEngine;
using System.Collections;

public class TextosUBI : MonoBehaviour {
	static TextosUBI instance;
	public GameObject texto1;
	public GameObject texto2;
	public GameObject texto3;
	public GameObject player;
	public GameObject human;
	public GameObject limit;

	//public bool lingote;
	private AudioSource audio;
	bool dentro;

	// Use this for initialization
	void Start () {
		//lingote = false;
		limit.SetActive (false);
		texto1.SetActive (false);
		texto2.SetActive (false);
		texto3.SetActive (false);
		audio = GetComponent<AudioSource>();
		instance = this;

	}
		
	void Update () {
		//Cuando le das el lingote
		if (GameManager.instance.lingote) {
			if (Input.GetKeyDown (KeyCode.E) && (dentro)) {
				texto2.SetActive (true);
				texto3.SetActive (true);
				audio.Play();
				human.SetActive (true);
				player.SetActive(false);
				limit.SetActive (true);


			}
		}
	}

	//Conversacion que te indica que hacer (conseguir el lingote)
	void OnTriggerEnter2D(Collider2D collider){
		texto1.SetActive (true);
		dentro = true;
	}

	void OnTriggerExit2D(Collider2D collider){
		texto1.SetActive (false);
		texto2.SetActive (false);
		texto3.SetActive (false);
		dentro = false;
	}
}