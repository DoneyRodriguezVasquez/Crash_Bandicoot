using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 16f;            // The speed that the player will move at.
	public float jumpSpeed = 12.0f;
	public float gravity = 2.0f;
	public float jumpAcc = 1.5f;
	public bool grounded;
	public bool spin;
	public bool spinning;

	CharacterController characterController;
	private Vector3 moveDirection = Vector3.zero;

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	public float vspeed;

	void Start ()
	{
		characterController = GetComponent<CharacterController>();
		// Set up references.
		vspeed = 0.0f;
		grounded = false;
		spinning = false;
	}
	void Update ()
	{
		grounded = characterController.isGrounded;
		spinning = false;
		if (characterController.isGrounded)
		{
			// We are grounded, so recalculate
			// move direction directly from axes
			vspeed = 0f;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection *= speed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
				vspeed += jumpAcc * Time.deltaTime;
			}
			else if (Input.GetButton("Spin")) {
				spinning = true;
			}
		}
		// Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
		// when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
		// as an acceleration (ms^-2)
		moveDirection.y -= gravity * Time.deltaTime;
		// Move the controller
		characterController.Move(moveDirection * Time.deltaTime);
	}


}