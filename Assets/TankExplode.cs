using UnityEngine;
using System.Collections;

public class TankExplode : MonoBehaviour {

	public void OnDeath() {
		Destroy (gameObject);
	}
}
