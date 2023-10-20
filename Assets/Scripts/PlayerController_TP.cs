using UnityEngine;
using System.Collections;

public class PlayerController_TP : MonoBehaviour {

	public float walkSpeed = 2f;

	public float rotationSmoothTime = 0.3f;
	float rotationSmoothVelocity;

	Transform cameraTransform;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDirection = input.normalized;

		if (inputDirection != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);
		}

		float speed = walkSpeed * inputDirection.magnitude;

		transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
	}
}
