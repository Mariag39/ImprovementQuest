using UnityEngine;
using System.Collections;

public class OnTrigger: MonoBehaviour {
	
	private behavierDrag drag;
	public GameObject lizard;
	private AudioSource source;
	public GameObject musica;
	public GameObject musicaBoss;
	public GameObject Save;
	public GameObject Princesa, Portal;
	public AudioClip grito;


	void Start() {
		lizard.GetComponent<behavierDrag> ();
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D info) {
		if (info.gameObject.tag == "trigger") {
			lizard.GetComponent<behavierDrag> ().dragon = true;
			musicaBoss.SetActive (true);
			Princesa.SetActive (false);
			Portal.SetActive (false);
			source.PlayOneShot (grito);
		}
		if (info.gameObject.tag == "trigger2") {
			Destroy (musica);
		}

	}
		

			

}
