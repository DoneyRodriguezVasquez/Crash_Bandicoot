using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour {

	public AudioClip sonido;
	AudioSource audio;
	public Animator animar;
	Collider col;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		col = GetComponent<Collider> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.tag == "Player"){
			audio.PlayOneShot (sonido, 0.4f);
			animar.SetTrigger ("kill");
			col.enabled = false;
		}
	}
}
