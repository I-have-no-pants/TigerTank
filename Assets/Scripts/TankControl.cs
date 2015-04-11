using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TankControl : MonoBehaviour {
	public WheelCollider[] m_WheelCollidersLeft;
	public WheelCollider[] m_WheelCollidersRight;
	public float Speed;

	public AudioSource a;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float threadsLeft = CrossPlatformInputManager.GetAxis ("TrackLeft");
		float threadsRight = CrossPlatformInputManager.GetAxis ("TrackRight");

		float leftThrustTorque = threadsLeft * Speed;
		float rightThrustTorque = threadsRight * Speed;

		a.volume = Mathf.Max (Mathf.Abs (threadsLeft), Mathf.Abs (threadsRight));

		for (int i = 0; i < m_WheelCollidersLeft.Length; i++) {
			m_WheelCollidersLeft[i].motorTorque = leftThrustTorque;
		}

		for (int i = 0; i < m_WheelCollidersRight.Length; i++) {
			m_WheelCollidersRight[i].motorTorque = rightThrustTorque;
		}
	}
}
