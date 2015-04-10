using UnityEngine;
using System.Collections;

public class AINavigator : MonoBehaviour {

	private NavMeshAgent agent;

	
	public TurretScript turret;


	public Transform goal;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();

	}

	void FixedUpdate() {
		var target = turret.GetVisualTarget ();
		if (target && target.GetComponent<HealthComponent>() != null) {
			turret.Fire();
		}
		agent.destination = goal.position; 
	}
}
