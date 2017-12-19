using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rb;
	private GameManager gameManager;
	private int lastRecKeyFrame;
	private bool bufferFull = false;
	private bool inPlayBack = false;

	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.recording) {
			Record(); 
		} else {
			PlayBack();
		}
		print ("Buffer full: " + bufferFull.ToString());
		print ("Am I in playback? -->" + inPlayBack.ToString()); 
	}

	void Record ()	{
		rb.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		print ("Wrinting keyframe: " + frame + ". Current frame count is: " + Time.frameCount);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
		if (!inPlayBack) {
			lastRecKeyFrame = Time.frameCount;
			}
		if (frame == bufferFrames) {
			bufferFull = true;
		}
		inPlayBack = false;
	}

	void PlayBack () {
		inPlayBack = true;
		rb.isKinematic = true;
		int frame;
		if (lastRecKeyFrame < bufferFrames && !bufferFull) {
			int newBufferFrames = lastRecKeyFrame;
			frame = Time.frameCount % newBufferFrames;
			Record();
		} else if (lastRecKeyFrame < bufferFrames && bufferFull) {
			frame = (Time.frameCount - lastRecKeyFrame) % bufferFrames;
		} else {
			frame = Time.frameCount % bufferFrames;
		}
		print ("Reading keyframe: " + frame + ". Current frame count is: " + Time.frameCount);
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}

	public struct MyKeyFrame {
		public float frameTime;
		public Vector3 position;
		public Quaternion rotation;

		public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
			frameTime = aTime;
			position = aPosition;
			rotation = aRotation;
		}
	}
}
