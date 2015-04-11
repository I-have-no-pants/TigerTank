using UnityEngine;
using System.Collections;

public class SwedishDestructible : MonoBehaviour {

	public int Swedishness;
	public void OnDeath() {
		FindObjectOfType<GameManager> ().DamageSweden (Swedishness);
		Destroy (gameObject);

	}
}
