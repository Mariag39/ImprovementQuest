using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public GameObject Player;
	public GameObject Checkpoint1, Checkpoint2, Checkpoint3, Begin;

	public new Vector3 PosRespawn;

	public bool spawn;

	void Start () {
		PosRespawn = Begin.transform.position;
	}

	void Update () {
		if ((Player.transform.position.x > 2061 && Player.transform.position.x < 2065) || (Player.transform.position.x > 108 && Player.transform.position.x < 114)) {
			if ((Player.transform.position.y < -716 && Player.transform.position.y > -720) || (Player.transform.position.y < -114 && Player.transform.position.y > -118)) {
				spawn = true;
				PosRespawn = Checkpoint1.transform.position;
			}
		}
		if ((Player.transform.position.x > 2610 && Player.transform.position.x < 2614) || (Player.transform.position.x > 16 && Player.transform.position.x < 20)) {
			if ((Player.transform.position.y < -756 && Player.transform.position.y > -760) || (Player.transform.position.y < -261 && Player.transform.position.y > -265)) {
				spawn = true;
				PosRespawn = Checkpoint2.transform.position;
			}
		}
		if ((Player.transform.position.x > 3098 && Player.transform.position.x < 3102) || (Player.transform.position.x < -328 && Player.transform.position.x > -332)) {
			if ((Player.transform.position.y < -905 && Player.transform.position.y > -909) || (Player.transform.position.y < -8 && Player.transform.position.y > -12)) {
				spawn = true;
				PosRespawn = Checkpoint3.transform.position;
			}
		}
	}
		
	void OnTriggerStay2D () {
		if (spawn)
			respawn ();
	}

	public void respawn () {
		Player.transform.position = PosRespawn;
	}

}
