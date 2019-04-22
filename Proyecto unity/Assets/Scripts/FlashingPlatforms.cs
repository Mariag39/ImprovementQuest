using UnityEngine;
using System.Collections;

public class FlashingPlatforms : MonoBehaviour {

	public GameObject Gobj;

	public float retardo;
	float cuenta;

	public bool invisible;

	private BoxCollider2D col;
	private Animator anim;

	// Use this for initialization
	void Start () {
		cuenta = retardo;
		col = Gobj.GetComponent<BoxCollider2D> ();
		anim = gameObject.GetComponent<Animator> ();
		invisible = false;
	}

	void Update (){
		cuenta -= Time.deltaTime;
		if (cuenta <= 0.0f) {
			if (invisible) {
				anim.SetBool ("invisible", invisible);
				col.isTrigger = true;
				invisible = false;
			} else {
				anim.SetBool ("invisible", invisible);
				col.isTrigger = false;
				invisible = true;
			}
			cuenta = retardo;
		}
	}
}
