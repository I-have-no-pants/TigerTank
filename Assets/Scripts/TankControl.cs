using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TankControl : MonoBehaviour {
	public WheelCollider[] LeftWheels;
	public WheelCollider[] RightWheels;

	public float Speed;

	float rightTorque;
	float leftTorque;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float threadsLeft = CrossPlatformInputManager.GetAxis ("TrackLeft");
		float threadsRight = CrossPlatformInputManager.GetAxis ("TrackRight");

		float leftThrustTorque = threadsLeft * Speed;
		float rightThrustTorque = threadsRight * Speed;

		foreach (var w in LeftWheels)
			w.motorTorque = leftThrustTorque;

		foreach (var w in RightWheels)
			w.motorTorque = rightThrustTorque;
	}
}
