using UnityEngine;
using System.Collections;

public class AITactics : MonoBehaviour {

	public GameObject target;
	public Transform navTarget;

	public float distance;

	public static bool CanReachTargetFrom(Vector3 pos, GameObject target) {
		Ray ray = new Ray (pos, (target.transform.position - pos).normalized);
		RaycastHit hit;
		Debug.DrawRay(pos, (target.transform.position - pos).normalized);
		if (Physics.Raycast (ray, out hit,10000)) {
			return hit.collider.gameObject == target;
		}
		return false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

		if (!CanReachTargetFrom(navTarget.position, target)) {
			Vector2 sphere = Random.insideUnitCircle;
			Vector3 sphere2 = new Vector3(sphere.x, 0, sphere.y);
			navTarget.position = target.transform.position + sphere2 * distance;
		}
	
	}
}