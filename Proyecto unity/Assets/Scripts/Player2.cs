using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
	
	//Floats
	public float maxspeed = 5;
	public float speed = 20f;
	public float jumpforce = 4f;
	public float jumppower = 1600;
	public float climbSpeed = 10;
	private float climbVelocity, gravityStore, AttackTimer, CoolDown; //Variables para determinar la velocidad de escalada, la gravedad, el tiempo de la animacion de ataque y el cooldown para poder realizar el siguiente ataque.
	public float Attack = 2.5f; 
	public float invulnerability = 0f; //Variable para determinar el tiempo de la animacion de ataque y  el tiempo de invulnerabilidad al recibir daño.
	public float dmg;
	public GameObject espada;
	public bool hacha;
	public GameObject HachaObj;
	private AudioSource source;

	//public bool Sword;

	//Boleans
	public bool dañado; //Variable para determinar cuando el jugador recibe daño y cuando no.
	//public bool FacingRight = true;
	//public bool wallJumping = false;
	//public bool wallJumped = false;
	//public bool wallTouching;
	//float checkRadius = 0.2f;

	public bool onLadder, canDoubleJump, grounded; //Variables para determinar cuando el jugador esta en la escalera, cuando puede realizar el doble salto y si esta tocando el suelo.

	//Mechanics Bools
	bool attack; //Variable para determinar cuando el jugador esta atacando.
	//public Transform wallcheck;
	//public LayerMask whatisGround;
	//public Transform groundCheck;
	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	private MovingPlatform platform;

	
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		gravityStore = rb2d.gravityScale;
		espada.SetActive (false);
	}
	
	void Update () {


		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
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
		
		if (Input.GetKeyDown (KeyCode.F)) {
			

			if (CoolDown < 0) {
				if (hacha) {
					HachaObj.SetActive (true);
					espada.SetActive (false);

				} else {
					espada.SetActive (true);

				}
				attack = true;
				anim.SetBool ("Attack", attack);
				AttackTimer = Attack;
				CoolDown = 0.4f;

			}
		}
		if (CoolDown <= 0) {
			if (hacha) {
				HachaObj.SetActive (false);
			} else {
				espada.SetActive (false);
			}
			attack = false;
			anim.SetBool ("Attack", attack);
		}


		//Movement
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			if (transform.localScale.x < 0) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, 4.4803f);
			}
			transform.position += Vector3.right * speed * Time.deltaTime;

		}

		if (Input.GetAxis ("Horizontal") < -0.1f) {	
			if (transform.localScale.x > 0){
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, 4.48f);
			}
			transform.position += Vector3.left * speed * Time.deltaTime;
		
		}
		//Jump of the player
		if (Input.GetButtonDown ("Jump") && !onLadder) {
			if (grounded) {
				jump ();
				canDoubleJump = true;
			} else if (canDoubleJump){
				canDoubleJump = false;
				rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
				jump ();
			}
		}
		//Climbing Ladder
		if (onLadder) {
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

	//Climb
	public void climb (float climbpower){
		rb2d.AddForce (Vector2.up * climbpower);
	}


	//For the player moving with the MovingPlatforms
	void OnCollisionEnter2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
		if (other.gameObject.tag == "corazon") {
			Destroy (other.gameObject);
			GameManager.instance.GanaCorazones ();
		}
		if (other.gameObject.tag == "Hacha") {
			Destroy (other.gameObject);
			hacha = true;


		}
	}
	
	void OnCollisionExit2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
			transform.localScale = new Vector3 (4.8f, 4.8f, 4.8f);
		}
	} 

		



 
}



