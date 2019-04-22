using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Floats
	public float maxspeed = 5;
	public float speed = 20f;
	public float jumppower = 1600;
	public float climbSpeed = 10;
	private float climbVelocity, gravityStore, AttackTimer, CoolDown; //Variables para determinar la velocidad de escalada, la gravedad, el tiempo de la animacion de ataque y el cooldown para poder realizar el siguiente ataque.
	public float Attack = 0.7f, invulnerability = 1.5f; //Variable para determinar el tiempo de la animacion de ataque y  el tiempo de invulnerabilidad al recibir daño.
	public float dmg;
	private AudioSource source;

	//Boleans
	bool air;
	public bool dañado; //Variable para determinar cuando el jugador recibe daño y cuando no.
	public bool onLadder, canDoubleJump, grounded;
	
	//Mechanics Bools
	public bool MovLeft, Ladder, Jump, Jump2, Sword, inicio, jugador;
	bool attack;
	
	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
		gravityStore = rb2d.gravityScale;
	}


	
	void Update () {

		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("Dañado", dañado);

		//Damaged
		dmg -= Time.deltaTime;

		if (dañado && dmg < 0) {
			anim.SetBool ("Dañado", dañado);
			dañado = false;
			dmg = invulnerability;
		}

		//Attack
		AttackTimer -= Time.deltaTime;
		CoolDown -= Time.deltaTime;
		
		if (Input.GetKey (KeyCode.F) && Sword) {
			if (CoolDown < 0) {
				attack = true;
				anim.SetBool ("Attack", attack);
				AttackTimer = Attack;
				CoolDown = 1f;
			}
		}
		if (AttackTimer <= 0) {
			attack = false;
			anim.SetBool ("Attack", attack);
		}

		//Movement
		if (Input.GetAxis ("Horizontal") > 0.1f && inicio) {
			transform.localScale = new Vector3 (9.3f, 9.3f, 1f);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetAxis ("Horizontal") < -0.1f && MovLeft) {
			transform.localScale = new Vector3 (-9.3f, 9.3f, -1f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		//Jump of the player
		if (Input.GetButtonDown ("Jump") && !onLadder && Jump) {
			if (grounded) {
				jump ();
				canDoubleJump = true;
			
			} else if (canDoubleJump && Jump2) {
				canDoubleJump = false;
				rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
				jump ();
			}
		}
		//Climbing Ladder
		if (onLadder && Ladder) {
			rb2d.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			rb2d.velocity = new Vector2 (rb2d.velocity.x, climbVelocity);
		} else {
			rb2d.gravityScale = gravityStore;
		}
	}

	//Jump
	public void jump (){
		rb2d.AddForce (Vector2.up * jumppower);


	}

	//For the player moving with the MovingPlatforms
	void OnCollisionEnter2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}
	
	void OnCollisionExit2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

	/*void movimiento (float Horizontal){
		if (!jugador) {
			if (Horizontal > 0.1f && inicio) {
				transform.localScale = new Vector3 (9.3f, 9.3f, 1f);
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else if (Horizontal < -0.1f && MovLeft){
				transform.localScale = new Vector3 (9.3f, 9.3f, 1f);
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
		} else {
			if (Horizontal > 0.1f){
				transform.localScale = new Vector3 (1.15f, 1f, 1f);
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else if (Horizontal < -0.1f){
				transform.localScale = new Vector3 (1.15f, 1f, 1f);
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
		}
	}*/

}



