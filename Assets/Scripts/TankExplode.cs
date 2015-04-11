using UnityEngine;
using System.Collections;

public class TankExplode : MonoBehaviour {

	public void OnDeath() {
		Destroy (GetComponent<AITactics>());
		Destroy (GetComponent<AINavigator>());
		Destroy (GetComponent<NavMeshAgent>());
		foreach (var r in GetComponentsInParent<Rigidbody>())
			r.isKinematic = false;
	}
}
