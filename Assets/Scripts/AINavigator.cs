using UnityEngine;
using System.Collections;

public class AINavigator : MonoBehaviour {

	private NavMeshAgent agent;

	public GameObject NavTargetPrefab;

	public Transform navTarget;

	
	void Start() {
		navTarget = Instantiate (NavTargetPrefab).gameObject.transform;
		agent = GetComponent<NavMeshAgent>();
	}
	
	void OnDestroy() {
		if(navTarget)
			Destroy (navTarget.gameObject);
	}

	
	public static bool CanReachTargetFrom(Vector3 pos, GameObject target) {
		Ray ray = new Ray (pos, (target.transform.position - pos).normalized);
		RaycastHit hit;
		Debug.DrawRay(pos, (target.transform.position - pos).normalized);
		if (Physics.Raycast (ray, out hit,10000)) {
			var h = hit.collider.gameObject == target;

			if (h)
				return true;

			if (hit.collider.gameObject == null)
				return false;

			Debug.Log(hit.collider.gameObject);

			foreach (var t in hit.collider.gameObject.GetComponentsInParent<Transform>()) {
				if (t.gameObject==target)
					return true;
			}
			return false;
		}
		return false;
	}


	void FixedUpdate() {
		if (navTarget)
			agent.destination = navTarget.position; 
	}
}
