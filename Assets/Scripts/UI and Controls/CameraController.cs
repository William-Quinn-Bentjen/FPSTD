using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Camera mainCamera;
    public float sensitivityX = 90;
    public float sensitivityY = 90;
    public float clampAngle = 80;
    public bool LockAtStart = true;
    private float rotY = 0;
    private float rotX = 0;
    // Use this for initialization
    void Start () {
		if (LockAtStart)
        {
            CursorLocked(LockAtStart);
        }
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
	}

    public void CursorLocked(bool locked = true)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Cursor.visible = locked;
    }
	// Update is called once per frame
	void Update () {
        Vector2 MouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (MouseMovement != Vector2.zero)
        {
            rotY += MouseMovement.x * sensitivityX * Time.deltaTime;
            rotX += -MouseMovement.y * sensitivityY * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }
	}
}
