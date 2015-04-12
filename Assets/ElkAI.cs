using UnityEngine;
using System.Collections;

public class ElkAI : MonoBehaviour {
	
	
	public TurretScript turret;
	private AINavigator navigator;
	
	public HealthComponent target;
	
	public float distance;
	
	public int EnemyTeam;
	
	public float ReloadTime;
	private float reloadTimer;
	
	private Animator animator;
	
	void Start() {
		navigator = GetComponent<AINavigator> ();
		animator = GetComponent<Animator> ();
	}
	
	// Logic for sorting
	public HealthComponent FindTarget() {
		foreach(var h in FindObjectsOfType<HealthComponent>()) {
			if (h.Team == EnemyTeam)
				return h;
		}
		return null;
	}
	
	public float killRadius;
	
	// Update is called once per frame
	void FixedUpdate() {
		
		if ((FindObjectOfType<KillSoldiers> ().transform.position - transform.position).magnitude < killRadius) {
			GetComponent<HealthComponent>().Health-=1;
		}

		
		if (reloadTimer > 0)
			reloadTimer -= Time.fixedDeltaTime;
		
		if (target == null || target.IsDead)
			target = FindTarget ();
		else {
			if (!AINavigator.CanReachTargetFrom (navigator.navTarget.position, target.gameObject)) {
				Vector2 sphere = Random.insideUnitCircle;
				Vector3 sphere2 = new Vector3 (sphere.x, 0, sphere.y);
				navigator.navTarget.position = target.transform.position + sphere2 * distance;
			}
		}
		
		
		/*
		// Calculate turret's target
		var turretTarget = turret.GetVisualTarget ();
		if (turretTarget) {
			var h = turretTarget.GetComponent<HealthComponent> ();
			if (h == null)
				h = turretTarget.GetComponentInParent<HealthComponent> ();
			
			if (h && h.Team == EnemyTeam) {
				if (reloadTimer <= 0) {
					turret.Fire ();
					reloadTimer = ReloadTime;
				}
			}
		}*/
	}
}
