using UnityEngine;
using System.Collections;

public class TankExplode : MonoBehaviour {

	public GameObject Explosion;

	public void OnDeath() {
		FindObjectOfType<SpawnerScript> ().EnemyKilled ();

		Destroy (GetComponent<AITactics>());
		Destroy (GetComponent<AINavigator>());
		Destroy (GetComponent<NavMeshAgent>());
		foreach (var r in GetComponentsInParent<Rigidbody>())
			r.isKinematic = false;

		foreach (var t in GetComponentsInChildren<TurrentTarget>())
			Destroy (t);

		Instantiate (Explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
