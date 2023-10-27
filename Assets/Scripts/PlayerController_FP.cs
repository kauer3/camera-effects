using UnityEngine;
using System.Collections;

public class PlayerController_FP : MonoBehaviour {

	public float walkSpeed = 3f;

	public GameObject firstPersonCameraObject;
	public GameObject thirdPersonCameraObject;

	bool inFirstPerson = false;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

		ManageToggleCamera();
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 inputDirection = input.normalized;

		transform.Translate (inputDirection * walkSpeed * Time.deltaTime);
	}

    private void ManageToggleCamera()
    {
		if (Input.GetMouseButtonDown(1))
		{
			if (inFirstPerson)
			{
				firstPersonCameraObject.SetActive(false);
				thirdPersonCameraObject.SetActive(true);
				inFirstPerson = false;
            }
            else
			{
				thirdPersonCameraObject.SetActive(false);
				firstPersonCameraObject.SetActive(true);
				inFirstPerson = true;
            }
		}
    }
}