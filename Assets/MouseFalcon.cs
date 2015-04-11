using UnityEngine;
using System.Collections;

public class MouseFalcon : MonoBehaviour {

	public bool active;
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (active) {
			target.localPosition = new Vector3( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

		}
	
	}
}
