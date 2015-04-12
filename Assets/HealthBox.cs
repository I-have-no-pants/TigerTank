using UnityEngine;
using System.Collections;

public class HealthBox : MonoBehaviour {

	public float distance;
	
	private WeaponSystem player;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<WeaponSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((player.transform.position - transform.position).magnitude < distance) {
			player.FindCrate ();
			Destroy(gameObject);
		}
		
	}
}
