using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {
	public GameObject myobject;
	public AudioClip sonido;
	AudioSource audio;
	public Camera camera;
	// Use this for initialization
	void Start () {
		audio = camera.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider obj){
		if (obj.tag.Equals("Player")){
			audio.PlayOneShot (sonido, 0.4f);
			gameObject.SetActive (false);
			myobject.SetActive(false);
		}
	}


}
