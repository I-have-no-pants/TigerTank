using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

	public AudioSource reload;

	public Animator animator;

	public int[] Ammo;
	public int ChoosenWeapon;

	public enum LoadState {
		NotLoaded, Loading, Loaded, Unloading
	}
	public LoadState loadState = LoadState.NotLoaded;

	public float UnloadTime;
	public float LoadTime;

	public float timer;

	public SphereManipulator falcon;

	public void ChangeWeapons(int i) {
		if (ChoosenWeapon != i) {
			ChoosenWeapon = i;
			if (loadState == LoadState.NotLoaded)
				Load ();
			else
				Unload();

		} else {
			Load ();
		}
	}

	public void Unload() {
		if (loadState != LoadState.NotLoaded) {
			loadState = LoadState.Unloading; // Quickload!
			timer = UnloadTime;
		}
	}

	public void FindCrate() {
		Ammo [0] += 5;
		reload.Play ();
	}


	public void Load() {

		if (loadState == LoadState.NotLoaded) {
			timer = LoadTime;		reload.Play ();
			loadState = LoadState.Loading; // Quickload!
			animator.SetTrigger("Reload");
		}
	}

	public bool CanFire() {
		return Ammo[ChoosenWeapon] > 0 && loadState == LoadState.Loaded;
	}

	public void FireWeapon() {
		Ammo [ChoosenWeapon]--;
		loadState = LoadState.NotLoaded;
	}




	public void OnDamage(object v) {
		animator.SetTrigger ("Hit");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Load1")) {
			ChangeWeapons(0);
		} else if (Input.GetButton("Load2")) {
			ChangeWeapons(1);
		}

		if (falcon.button_states[1])
			ChangeWeapons(1);
			

		switch (loadState) {
		case LoadState.Loading:
			if (timer <= 0) {
				loadState = LoadState.Loaded;
			}
			break;
		case LoadState.Unloading:
			if (timer <= 0) {
				loadState = LoadState.NotLoaded;
			}
			break;
		}

		if (timer > 0)
			timer -= Time.deltaTime;
	
	}
}
