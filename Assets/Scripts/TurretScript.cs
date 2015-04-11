﻿using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	public float MaxDistance;

	public GameObject MuzzleFlash;

	public BulletScript bullet;
	public Transform muzzle;
	public float Velocity;
	
	public void Fire() {
		BulletScript b = Instantiate (bullet, muzzle.position, muzzle.rotation) as BulletScript;
		b.turretCollider = GetComponent<Collider> ();
		b.GetComponent<Rigidbody> ().velocity = Velocity * muzzle.forward;
		if(MuzzleFlash)
			Instantiate (MuzzleFlash, muzzle.position, muzzle.rotation);
		
	}

	public GameObject GetVisualTarget() {
		Ray ray = new Ray (muzzle.position, muzzle.forward);
		RaycastHit hit;
		Debug.DrawRay(muzzle.position, muzzle.forward);
		if (Physics.Raycast (ray, out hit, MaxDistance)) {
			return hit.collider.gameObject;
		}
		return null;
	}
}
