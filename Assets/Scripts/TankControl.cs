using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TankControl : MonoBehaviour {
	WheelCollider[] m_WheelColliders;
	WheelCollider[] m_WheelCollidersLeft;
	WheelCollider[] m_WheelCollidersRight;
	float m_CurrentTorque;

	// Use this for initialization
	void Start () {
		m_WheelColliders = GetComponentsInChildren<WheelCollider> ();

		m_WheelCollidersLeft = new WheelCollider[4];
		m_WheelCollidersRight = new WheelCollider[4];
		for(int i = 0; i < m_WheelColliders.Length; i++) {
			if(m_WheelColliders[i].name.Contains ("left")) {
				m_WheelCollidersLeft[i % 4] = m_WheelColliders[i];
			} else {
				m_WheelCollidersRight[i % 4] = m_WheelColliders[i];
			}		
		}

		m_CurrentTorque = 300;
	}
	
	// Update is called once per frame
	void Update () {
		float threadsLeft = CrossPlatformInputManager.GetAxis ("Horizontal");
		float threadsRight = CrossPlatformInputManager.GetAxis ("Vertical");

		float leftThrustTorque = threadsLeft * (m_CurrentTorque / (float)m_WheelCollidersLeft.Length);
		float rightThrustTorque = threadsRight * (m_CurrentTorque / (float)m_WheelCollidersRight.Length);

		for (int i = 0; i < m_WheelCollidersLeft.Length; i++) {
			m_WheelCollidersLeft[i].motorTorque = leftThrustTorque;
		}

		for (int i = 0; i < m_WheelCollidersRight.Length; i++) {
			m_WheelCollidersRight[i].motorTorque = rightThrustTorque;
		}
	}
}
