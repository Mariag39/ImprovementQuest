using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public bool Started;
	Rigidbody2D clone;
	private Animator anim;
	public GameObject fireball;
	public Transform target;
	public float OnSight = 20f;
	public float range = 3f;
	public float speed = 200f;
	public float walkSpeed = 4.0f;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	public float InstantiationTimer = 0f;
	public Player2 player;
	public Transform LaunchPoint;
	public bool grounded;
	public float Timer = 0f;


	void Start () {
		anim = GetComponent<Animator>();
		clone = GetComponent<Rigidbody2D> ();
		currentPoint = points[pointSelection];
		player = FindObjectOfType<Player2> ();
		anim.SetBool ("Grounded", true);

	}


	// Update is called once per frame
	void Update () {
		
		if (Started) {
			    Timer -= Time.deltaTime;
				InstantiationTimer -= Time.deltaTime;
			  if (InstantiationTimer <= 0) {
				InstantiationTimer = 2.5f;
				clone = (Instantiate (fireball, LaunchPoint.position, LaunchPoint.rotation)) as Rigidbody2D;

				anim.SetBool ("MoveRight", true);
			}
			
			transform.position = Vector3.MoveTowards (transform.position, currentPoint.position, Time.deltaTime * walkSpeed);
			
			if (transform.position == currentPoint.position) {
				if (Timer < -2) {
					Timer = 3f;
					anim.SetBool ("Grounded", grounded);
					anim.SetBool ("MoveRight", false);
					fireball.SetActive (false);
					pointSelection++;
				}
				if (Timer < 0) {
					if (pointSelection > points.Length) {
						pointSelection = 0;
					}
					currentPoint = points [pointSelection];
					fireball.SetActive (true);
					anim.SetBool ("MoveRight", true);
				}
			}
		}
	}
}

