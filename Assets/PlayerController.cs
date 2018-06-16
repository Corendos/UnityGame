using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkAcceleration = 1f;
	public float runAcceleration = 4f;

	public float maxWalkSpeed = 1f;
	public float maxRunSpeed = 1f;
	public float jumpingSpeed = 4f;
	public bool jumping = false;

	public float drag;
	public float deadzone;

	Rigidbody r;

	void Start () {
		r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? maxRunSpeed : maxWalkSpeed;
		float currentAcceleration = Input.GetKey(KeyCode.LeftShift) ? runAcceleration : walkAcceleration;

		Vector2 direction = new Vector2(Input.GetAxisRaw("X"), Input.GetAxisRaw("Z")).normalized;
		Vector2 tempVelocity = new Vector2(r.velocity.x, r.velocity.z);
		Vector2 acceleration = direction * currentAcceleration;
		Vector2 dragForce = drag * tempVelocity * tempVelocity.magnitude;

		tempVelocity += Time.deltaTime * (acceleration - dragForce);
		if (tempVelocity.magnitude > currentSpeed) {
			tempVelocity = tempVelocity.normalized * currentSpeed;
		} else if (tempVelocity.magnitude < deadzone) {
			tempVelocity = Vector2.zero;
		}

		r.velocity = new Vector3(tempVelocity.x, r.velocity.y, tempVelocity.y);

		if (!jumping && Input.GetKeyDown(KeyCode.Space)) {
			r.velocity = new Vector3(0, jumpingSpeed, 0) + r.velocity;
			jumping = true;
		}
	}

	void OnCollisionEnter() {
		jumping = false;
	}
}
