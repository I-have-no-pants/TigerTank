using UnityEngine;
using System.Collections;

public class PlayerTurret : MonoBehaviour {

	public WeaponSystem weapons;
	public TurretScript[] turrets;

	public SphereManipulator sphere;

	public Animator falconAnimator;

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton ("Fire1") || sphere.button_states[0]) {
			if (weapons.CanFire()) {
				turrets[weapons.ChoosenWeapon].Fire();
				falconAnimator.SetTrigger("Fire");
				if (weapons.ChoosenWeapon != 1) 
					weapons.FireWeapon();
			}
		}

	}
}
