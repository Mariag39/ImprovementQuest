using UnityEngine;
using System.Collections;

public class EnemyDungeons : MonoBehaviour {

	public GameObject Player;
	private Animator anim;
	public Transform target;

	public float speed = 2f;
	public float range = 3f;
	public float OnSight = 20f;

	private Player2 player;


	void Start () {
		anim = GetComponent<Animator>();
		player = FindObjectOfType<Player2> ();
	}


	void Update () {

		transform.LookAt (target.position);

		transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z);

		if (Vector3.Distance (transform.position, target.position) < OnSight) {
			if (target.position.x < transform.position.x && Vector3.Distance (transform.position, target.position) > range) { 
				anim.SetBool ("MoveLeft", true);
				anim.SetBool ("Move", false);
				anim.SetBool ("PlayerInSight", true);
				anim.SetBool ("LookingRight", false);
				anim.SetBool ("Idle", false);

				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime * speed);
			

			} else if (target.position.x > transform.position.x && Vector3.Distance (transform.position, target.position) > range) {
				anim.SetBool ("MoveLeft", false);
				anim.SetBool ("Move", true);
				anim.SetBool ("LookingRight", true);
				anim.SetBool ("PlayerInSight", false);
				anim.SetBool ("Idle", false);

				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime * speed);
			
			}
		}
	}

}
