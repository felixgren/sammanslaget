using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[Range(0, 0.1f)]
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

	private void Update() {
		float scrollAxis = Input.GetAxis("Mouse ScrollWheel");

		if(scrollAxis != 0) {
			velocity = Mathf.Clamp(scrollAxis + velocity, -maxVelocity, maxVelocity);
		}
		else {
			float direction = Mathf.Sign(velocity);
			velocity += (drag * 0.001f) * -direction;
		}


		currentTimeStep += velocity * speedMultiplier;

		var normalizedStep = currentTimeStep / totalTimeStep;
		Debug.Log(normalizedStep);
		moveAnimController.Play("Move", -1, normalizedStep);
	}
}
