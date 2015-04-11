using UnityEngine;
using System.Collections;

public class TurrentTarget : MonoBehaviour {

	public TurretScript turret;

	public HealthComponent target;

	public int EnemyTeam;

	// Use this for initialization
	void Start () {
	
	}

	public HealthComponent FindTarget() {
		foreach(var h in FindObjectsOfType<HealthComponent>()) {
			if (h.Team == EnemyTeam && AINavigator.CanReachTargetFrom(turret.muzzle.transform.position, h.gameObject))
				return h;

		}
		return null;
	}

	public float MaxRotation;

	// Update is called once per frame
	void FixedUpdate () {

		if (target == null || !AINavigator.CanReachTargetFrom(turret.muzzle.transform.position, target.gameObject)) {
			target = FindTarget();
		}

		// Rotate
		if (target != null) {
			transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( target.transform.position- transform.position, new Vector3(0,1,0)), MaxRotation * Time.fixedDeltaTime);
		}


	}
}
