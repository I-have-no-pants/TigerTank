using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float Size;
	public float Damage;
	public float Lifetime;

	public float Force;
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject, Lifetime);
		foreach (var collision in Physics.SphereCastAll(transform.position,Size,Vector3.up)) {
			var h = collision.collider.GetComponent<HealthComponent>();
			if (!h)
				h = collision.collider.GetComponentInParent<HealthComponent>();
				
			if (h)
				h.Health -= Damage;

			var r = collision.rigidbody;
			if (r) {
				if (!r.isKinematic)
					r.AddForceAtPosition(Force * collision.point - transform.position,collision.point);

			}
		}
	}
	
}
