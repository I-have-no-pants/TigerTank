using UnityEngine;
using System.Collections;

public class HealthBox : MonoBehaviour {

	public float distance;
	
	private HealthComponent player;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<WeaponSystem> ().GetComponent<HealthComponent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((player.transform.position - transform.position).magnitude < distance) {
			player.health+=20;
			Destroy(gameObject);
		}
		
	}
}
