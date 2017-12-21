using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

	private GameObject player;
	private Vector3 armRotation;

	public float panSpeed;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		armRotation.y += CrossPlatformInputManager.GetAxis ("RHor") * panSpeed;
		armRotation.y = Mathf.Clamp(armRotation.y, -25f, 25f);
		armRotation.z += Input.GetAxis ("RVer") * panSpeed;
		armRotation.z = Mathf.Clamp(armRotation.z, -90f, -35f);
		transform.position = player.transform.position;
		transform.rotation = Quaternion.Euler(armRotation);
	}
}
