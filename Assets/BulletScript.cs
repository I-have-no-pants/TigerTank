using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject Explosion;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	void OnCollisionEnter(Collision collision) {

		if (Explosion != null) {
			Instantiate(Explosion, transform.position, Quaternion.identity);
		}

		Destroy (gameObject);
	}
}
