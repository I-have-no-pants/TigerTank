using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {

	public Transform track;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var p = track.position;
		p.y = transform.position.y;
		transform.position = p;

		/*p = track.rotation.eulerAngles;
		p.x = 90;
		p.z = 0;
		transform.rotation = Quaternion.Euler (p);*/
	
	}
}
