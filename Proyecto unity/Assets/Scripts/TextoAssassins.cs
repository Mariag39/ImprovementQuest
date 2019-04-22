using UnityEngine;
using System.Collections;

public class TextoAssassins : MonoBehaviour {

	public GameObject texto1;
	public GameObject texto2;
	private bool dentro;
	private bool hablado;
	private AudioSource audio;
	bool escuchado = false;
	public GameObject braguitas;
	public GameObject suje;
	public GameObject bandana;
	public GameObject pulseras;

	// Use this for initialization
	void Start () {
		hablado = false;
		dentro = false;
		texto1.SetActive (false);
		texto2.SetActive (false);
		audio = GetComponent<AudioSource>();
	}

	void hablar (bool dentro){
		if (dentro) {
			texto1.SetActive (true);
			texto2.SetActive (true);
			hablado = true;
			escuchado = true;
			audio.Play();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (!hablado) {
			dentro = true;
			hablar (dentro);
		}

	}

	void OnTriggerExit2D(Collider2D collider){
		texto1.SetActive (false);
		texto2.SetActive (false);
		dentro = false;
		suje.SetActive (true);
		braguitas.SetActive (true);
		bandana.SetActive (true);
		pulseras.SetActive (true);


	}





}
