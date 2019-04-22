using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	/*Vector3 velocidad;
	Vector3 origen;
	Transform transf;
	public float distancia;
	public float speed;
	float distOrigen;
	bool izquierda = false;*/
	AudioSource sonido;
	GameManager gm;
	private Player player;
	public GameObject platform;

	public float moveSpeed;

	public Transform currentPoint;

	public Transform[] points;

	public int pointSelection;

	void Start () {
		player = FindObjectOfType<Player> ();
		currentPoint = points[pointSelection];
	}
		
	void Update () {

		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if (platform.transform.position == currentPoint.position) {
			pointSelection++;
			if(pointSelection > points.Length) {
				pointSelection = 0;
			}
			currentPoint = points[pointSelection];
		}
	}

	void OnCollisionEnter2D(Collision2D info) {
		if (info.gameObject.tag == "Player") {
			GameManager.instance.PierdeCorazones ();
			player.dañado = true;
			Debug.Log ("mataaaaar");
		}
	}
}