using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
	private bool spinning;
	private bool grounded;
	private bool spin;
	private Vector2 input;
	public float hspeed;
	Animator anim;                      // Reference to the animator component.
	public float vs;
	PlayerMovement p1;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		p1 = GetComponent <PlayerMovement> ();
		spinning = false;
		grounded = true;
		spinning = false;
		hspeed = 0f;
		vs = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		vs = p1.vspeed;
		grounded = p1.grounded;
		spinning = p1.spinning;
		// Animate the player.
		Animating ();
	}
	void Animating ()
	{
		input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		// Tell the animator whether or not the player is walking.
		hspeed = input.sqrMagnitude;
		anim.SetFloat("hspeed", input.sqrMagnitude);
		anim.SetFloat ("vspeed", vs);
		anim.SetBool("ground", grounded);
		//anim.SetBool("spinning", spinning);
		//anim.SetBool ("jumping", jumping);
		//anim.SetBool ("walking", walking);
		if (spinning) {
			anim.SetTrigger ("spin");
			//anim.SetBool ("spinning", !spinning);
		}
	}
}
