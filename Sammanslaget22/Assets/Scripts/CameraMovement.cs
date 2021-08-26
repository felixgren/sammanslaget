using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[Range(0, 1f)]
	[SerializeField]
	private float speedMultiplier = 0.9f;
	
	[Range(0, 1f)]
	[SerializeField]
	private float drag;

	[SerializeField]
	private float maxVelocity = 10f;

	[SerializeField]
	private AnimationClip moveAnimClip;

	private Animator moveAnimController;
	private float currentTimeStep = 0f;
	private float totalTimeStep = 1f;
	private float velocity;


	private void Start() {
		moveAnimController = GetComponent<Animator>();
		moveAnimController.speed = 0;
		totalTimeStep = moveAnimClip.length;
	}

	private void FixedUpdate() {
		float scrollAxis = Input.GetAxisRaw("Mouse ScrollWheel");

		velocity = Mathf.Clamp(scrollAxis + velocity, -maxVelocity, maxVelocity);
		float direction = Mathf.Sign(velocity);
		velocity += (drag * 0.01f) * -direction;

		currentTimeStep += velocity * speedMultiplier;
		currentTimeStep = Mathf.Clamp(currentTimeStep, 0, totalTimeStep);


		var normalizedStep =  Mathf.Clamp(currentTimeStep / totalTimeStep, 0, 1);

		moveAnimController.Play("Move", -1, normalizedStep);

		if (currentTimeStep <= 0 || currentTimeStep >= totalTimeStep)
			velocity = 0;
		
	}
}
