using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField]
	private float speedMultiplier = 0.9f;
	[SerializeField]
	private float drag = 0.9f;

	private float currentTimeStep = 0f;
	private float totalTimeStep = 1f;
	private float velocity;
	private float maxVelocity = 10f;

	[SerializeField]
	private Animation moveAnim;

	private Animator moveAnimController;

	private void Start() {
		moveAnimController = GetComponent<Animator>();
		moveAnimController.speed = 0;
		totalTimeStep = moveAnim.clip.length;
	}

	private void Update() {
		float scrollAxis = Input.GetAxis("Mouse ScrollWheel");

		if(scrollAxis != 0) {
			velocity = Mathf.Clamp(scrollAxis + velocity, -maxVelocity, maxVelocity);
		}
		else {
			float direction = Mathf.Sign(velocity);
			velocity += drag * -direction;
		}

		currentTimeStep += velocity * speedMultiplier;

		var normalizedStep = currentTimeStep / totalTimeStep;
		//Debug.Log(scrollAxis);
		moveAnimController.Play("Move", -1, normalizedStep);
	}
}
