using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject Explosion;

	public Collider turretCollider;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.collider != turretCollider) {

			if (Explosion != null) {
				Instantiate (Explosion, transform.position, Quaternion.identity);
			}

			Destroy (gameObject);
		}
	}
}
