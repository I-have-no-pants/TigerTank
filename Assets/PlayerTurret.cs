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

	public float MachinegunSpeed;
	public float timer;

	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButton ("Fire1") || sphere.button_states[0]) {
			if (weapons.ChoosenWeapon == 0) {
				if (weapons.CanFire()) {
					turrets[weapons.ChoosenWeapon].Fire();
					falconAnimator.SetTrigger("Fire");
					if (weapons.ChoosenWeapon != 1) 
						weapons.FireWeapon();
				}
			} else {
				if (Input.GetButton ("Fire1") ||sphere.button_states[0]) {
					if (timer <=0) {
						turrets[weapons.ChoosenWeapon].Fire();
						
						falconAnimator.SetTrigger("Machinegun");
						timer = MachinegunSpeed;
					} else {
						timer -= Time.deltaTime;
					}
				} else {
				}

			}
		}

	}
}
