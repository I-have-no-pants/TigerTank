using UnityEngine;
using System.Collections;

public class KillSoldiers : MonoBehaviour {

	public GameObject gameOver;
	public void OnDeath() {
		gameOver.SetActive (true);
	}

	public Explosion e;
	/*
	void OnCollisionEnter(Collision collision) {

		if (e != null) {
			Instantiate (e, collision.contacts[0].point, Quaternion.identity);
			Debug.Log ("Collisde");
		}

	}*/
}
