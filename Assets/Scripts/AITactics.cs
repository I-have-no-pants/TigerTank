using UnityEngine;
using System.Collections;

public class AITactics : MonoBehaviour {
	
	public TurretScript turret;
	private AINavigator navigator;
	
	public GameObject target;
	
	public float distance;

	public int EnemyTeam;

	void Start() {
		navigator = GetComponent<AINavigator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate() {

		if (!AINavigator.CanReachTargetFrom(navigator.navTarget.position, target)) {
			Vector2 sphere = Random.insideUnitCircle;
			Vector3 sphere2 = new Vector3(sphere.x, 0, sphere.y);
			navigator.navTarget.position = target.transform.position + sphere2 * distance;
		}

		// Calculate turret's target
		var turretTarget = turret.GetVisualTarget ();
		if (turretTarget) {
			var h = turretTarget.GetComponent<HealthComponent>();
			if (h == null)
				h = turretTarget.GetComponentInParent<HealthComponent>();
				
			if (h && h.Team == EnemyTeam) {
				turret.Fire();
			}
		}
	
	}
}