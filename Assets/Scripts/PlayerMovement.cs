using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

	public Animator animator;

	public CharacterController2D controller;

	public float Speed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

	// Update is called once per frame
	void Update()
	{

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("Jumping", true);
		}
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Secret"))
		{
			Speed = 70f;
		}
	}
}
