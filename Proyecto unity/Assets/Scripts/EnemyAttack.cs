using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject Player;
	private Animator anim;
	public Transform target;

	public float speed = 2f;
	public float range = 3f;
	public float OnSight = 20f;
	private Transform ardilla;

	void Start () {
		anim = GetComponent<Animator>();

	}
	

	void Update () {
		
		transform.LookAt (target.position);

		transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z);

		if (Vector3.Distance (transform.position, target.position) < OnSight) {
			if (target.position.x < transform.position.x && Vector3.Distance (transform.position, target.position) > range) { 
				transform.position -= transform.right * speed * Time.deltaTime;
				anim.SetBool ("PlayerInSight", true);
				anim.SetBool ("LookingRight", false);
				anim.SetBool ("Idle", false);
			} else if (target.position.x > transform.position.x && Vector3.Distance (transform.position, target.position) > range) {
				anim.SetBool ("LookingRight", true);
				anim.SetBool ("PlayerInSight", false);
				anim.SetBool ("Idle", false);
				transform.position += transform.right * speed * Time.deltaTime; 
			} else {
				anim.SetBool ("Idle", true);
				anim.SetBool ("PlayerInSight", false);
				anim.SetBool ("LookingRight", false);
			}
		}else if ((Vector3.Distance (transform.position, target.position) < range) || (Vector3.Distance (transform.position, target.position) > OnSight)) {
				anim.SetBool ("Idle", true);
				anim.SetBool ("PlayerInSight", false);
				anim.SetBool ("LookingRight", false);
			}
	}
}
  

