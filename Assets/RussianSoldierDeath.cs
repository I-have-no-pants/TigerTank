﻿using UnityEngine;
using System.Collections;

public class RussianSoldierDeath : MonoBehaviour {

	public GameObject Blood;

	public GameObject AmmoBox;

	public float AmmoChance;

	public void OnDeath() {

		if (Random.Range (0f, 1f) < AmmoChance) {
			Instantiate(AmmoBox, transform.position, Quaternion.identity);
		}

		FindObjectOfType<SpawnerScript> ().EnemyKilled ();
		
		Destroy (GetComponent<RussianSoldierAI>());
		Destroy (GetComponent<AINavigator>());
		Destroy (GetComponent<NavMeshAgent>());
		foreach (var r in GetComponentsInParent<Rigidbody>())
			r.isKinematic = false;
		
		foreach (var t in GetComponentsInChildren<TurrentTarget>())
			Destroy (t);
		Instantiate (Blood, transform.position, transform.rotation);

		Destroy (gameObject);
	}
}
