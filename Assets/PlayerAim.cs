using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Ray ray = new Ray (transform.position, transform.forward);;
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {

		}
	
	}
}
