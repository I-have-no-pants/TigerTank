using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	public BulletScript bullet;
	public Transform muzzle;
	public float Velocity;
	
	public void Fire() {
		BulletScript b = Instantiate (bullet, muzzle.position, muzzle.rotation) as BulletScript;
		b.turretCollider = GetComponent<Collider> ();
		b.GetComponent<Rigidbody> ().velocity = Velocity * muzzle.forward;
	}
}
