using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public int corazones = 3;
	public GameObject Play;
	public GameObject Credits;
	public GameObject corazon1;
	public GameObject corazon2;
	public GameObject corazon3;
	public GameObject armadura;
	public GameObject panelRestart;
	public GameObject Player, Princesa, Portal, musicaBoss;
	public bool lingote, spawn, nota;
	public GameObject panelInicio;
	private Player player;
	public float dmg;
	public bool armor;
	public GameObject uno;
	public GameObject dos;
	public GameObject tres;
	public GameObject cuatro;
	public GameObject cinco;
	public GameObject seis;
	public GameObject siete;
	public GameObject ocho;
	public GameObject nueve;
	public GameObject diez;
	public int vidas = 10;
	public GameObject dragon;

	public new Vector3 PosRespawn;

	public Respawn respawn;

	//public bool inicio;

	void Start () {
		instance = this;
		panelInicio.SetActive (true);
		player = FindObjectOfType<Player> ();
	}
		
	
	// Update is called once per frame
	void Update () {
		PosRespawn = respawn.PosRespawn;
		dmg -= Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.E)) {
			panelInicio.SetActive (false);
			player.inicio = true;
		}
	}

	public void PierdeCorazones () {
		if (dmg < 0) {
		corazones--;
		if (armor) {
			armadura.gameObject.SetActive (true);
		}
		if (corazones == 2) {
			corazon3.gameObject.SetActive (false);
		} 
		if (corazones == 1) {
			corazon2.gameObject.SetActive (false);
		} 
			if (corazones == 0) {
				corazon1.gameObject.SetActive (false);
				panelRestart.SetActive (true);
				//Destroy (Player);
				Player.SetActive (false);
			}
			dmg = 1.5f;
		}
	}

	public void GanaCorazones(){
		if (corazones == 2) {
			corazon3.gameObject.SetActive (true);
			corazones++;
		}
	
		if (corazones == 1) {
			corazon2.gameObject.SetActive (true);
			corazones++;
		}
	}

	public void DañoDragon(){
		vidas--;
		if (vidas == 8)
			uno.SetActive (false);
		if (vidas == 7)
			dos.SetActive (false);
		if (vidas == 6)
			tres.SetActive (false);
		if (vidas == 5)
			cuatro.SetActive (false);
		if (vidas == 4)
			cinco.SetActive (false);
		if (vidas == 3)
			seis.SetActive (false);
		if (vidas == 2)
			siete.SetActive (false);
		if (vidas == 1)
			ocho.SetActive (false);
		if (vidas == 0) {
			nueve.SetActive (false);
			Destroy (dragon);
			Princesa.SetActive (true);
			Portal.SetActive (true);
			musicaBoss.SetActive (false);
		}
	}


	//Este metodo deberiamos utilizarlo para reinciar nivel en el menu pausa o al morir
	public void Reset () {
		//Application.LoadLevel (Application.loadedLevel);
		if (Application.loadedLevel == 1){
			Application.LoadLevel (1);
		}
		panelRestart.SetActive (false);
		corazones = 3;
		corazon1.gameObject.SetActive (true);
		corazon2.gameObject.SetActive (true);
		corazon3.gameObject.SetActive (true);
		Player.SetActive (true);
		respawn.respawn ();
	}


	public void OnJugarClick() {
		Application.LoadLevel (1);
	}
	public void OnSalirClick() {
		Application.LoadLevel (0);
	}
	public void OnCreditosClick() {
		Application.LoadLevel (5);
	}
	public void OnTutoClick() {
		Application.LoadLevel (1);
	}
	public void OnLevel1Click() {
		Application.LoadLevel (2);
	}
	public void OnLevel2Click() {
		Application.LoadLevel (3);
	}
	public void OnSelNivelClick() {
		Application.LoadLevel (7);
	}
	public void OnControlClick() {
		Application.LoadLevel (6);
	}
}
