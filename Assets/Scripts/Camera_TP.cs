using UnityEngine;
using System.Collections;

public class Camera_TP : MonoBehaviour {

	public float mouseSensitivity = 10;
	float xRotation;
	float yRotation;

	public Transform target;
	public float distance = 3;

	public Vector2 yMinMax = new Vector2 (-20, 80);

	// Update is called once per frame
	void Update () {
		xRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
		yRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		yRotation = Mathf.Clamp (yRotation, yMinMax.x, yMinMax.y);

		Vector3 targetRotation = new Vector3(yRotation, xRotation);
		transform.eulerAngles = targetRotation;

		transform.position = target.position - distance * transform.forward;
	}
}
