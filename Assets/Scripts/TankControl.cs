using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TankControl : MonoBehaviour {
	WheelCollider[] m_WheelColliders;
	float m_CurrentTorque;
	// Use this for initialization
	void Start () {
		m_WheelColliders = GetComponentsInChildren<WheelCollider> ();
		m_CurrentTorque = 300;
	}
	
	// Update is called once per frame
	void Update () {
		float threadsLeft = CrossPlatformInputManager.GetAxis ("Horizontal");
		float threadsRight = CrossPlatformInputManager.GetAxis ("Vertical");

		float leftThrustTorque = threadsLeft * (m_CurrentTorque / 2f);
		float rightThrustTorque = threadsRight * (m_CurrentTorque / 2f);
		// Assume wheel 0 and 1 are on the same side.
		m_WheelColliders[0].motorTorque = m_WheelColliders[1].motorTorque = leftThrustTorque;
		// Assume wheel 2 and 3 are on the same side.
		m_WheelColliders[2].motorTorque = m_WheelColliders[3].motorTorque = rightThrustTorque;
	}
}
