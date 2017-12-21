using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;
	private bool paused = false;
	private float initialDTime;

	void Start () {
		initialDTime = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1")) {
			recording = false;
		} else {
			recording = true;
		}

		if (CrossPlatformInputManager.GetButtonDown ("Pause") && !paused){
			Pause ();
		} else if (CrossPlatformInputManager.GetButtonDown("Pause") && paused) {
			Resume ();
		}
	}

	void Pause ()
	{
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
		paused = true;
	}

	void Resume ()
	{
		Time.timeScale = 1;
		Time.fixedDeltaTime = initialDTime;
		paused = false;
	}
}
