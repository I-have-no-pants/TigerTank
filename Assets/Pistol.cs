using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public SphereManipulator Falcon;

	private bool fire;
	public ParticleSystem pew;
	// Update is called once per frame
	void Update () {
		if (Falcon.button_states [0]) {
			if (!fire) {
				Falcon.constantforce = new Vector3 (0, 0, -30);
				pew.Play();
				fire = true;
			}
		} else {
			Falcon.constantforce = new Vector3 (0, 0, 0);
			fire = false;
		}
	
	}
}
