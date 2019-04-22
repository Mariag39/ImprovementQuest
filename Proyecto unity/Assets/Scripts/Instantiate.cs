using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
	
	Rigidbody2D clone;
	public GameObject fireball;
	public float InstantiationTimer = 0f;
	public Player2 player;
	public Transform LaunchPoint;

	// Use this for initialization
	void Start () {
		clone = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<Player2> ();
	}
	
	// Update is called once per frame
	void Update () {
		InstantiationTimer -= Time.deltaTime;
		if (InstantiationTimer <= 0) {
			InstantiationTimer = 2.5f;
			clone = (Instantiate (fireball, LaunchPoint.position, LaunchPoint.rotation)) as Rigidbody2D;

		}
	}
}
