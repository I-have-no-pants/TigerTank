using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public float _MAXHEALTH;
	public float health;
	public float Health {
		get {
			return health;
		}
		set {
			if (value <= 0 && health > 0) {
				health = 0;
				SendMessage("OnDeath");
				Debug.Log(gameObject + " died!");
				//Destroy(this);

			} else {
				SendMessage("OnDamage",value,SendMessageOptions.DontRequireReceiver);
				health = value;
				Debug.Log(gameObject + " health: " + health);
			}
		}
	}
}
