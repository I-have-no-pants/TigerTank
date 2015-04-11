using UnityEngine;
using System.Collections;

public class PlayerTurret : MonoBehaviour {

	public WeaponSystem weapons;
	public TurretScript[] turrets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton ("Fire1")) {
			if (weapons.CanFire()) {
				turrets[weapons.ChoosenWeapon].Fire();
				if (weapons.ChoosenWeapon != 1)
					weapons.FireWeapon();
			}
		}

	}
}
