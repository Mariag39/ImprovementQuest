using UnityEngine;
using System.Collections;

public class behavierDrag : MonoBehaviour {
	public float walkSpeed = 4.0f;

	Vector3 walkAmount;
	public bool dragon;
	public Transform currentPoint;
	private Animator anim;
	private Boss final;
	public GameObject boss;




	void Start() {
		dragon = false;
		anim = GetComponent<Animator> ();



	}

	void Update () {
		if (dragon) {

			anim.SetBool ("MoveLeft", true);
			transform.position = Vector3.MoveTowards (transform.position, currentPoint.position, Time.deltaTime * walkSpeed);

		}
		if (transform.position == currentPoint.position) {
			anim.SetBool ("MoveLeft", false);
			boss.GetComponent<Boss> ().Started = true;

		}
}
}
