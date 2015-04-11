using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSystemGUI : MonoBehaviour {

	public Slider slider;
	public WeaponSystem weapons;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (weapons.loadState == WeaponSystem.LoadState.Loaded) {
			slider.value = 1;
			slider.maxValue = 1;
		}else if (weapons.loadState == WeaponSystem.LoadState.Loading) {
			slider.value = weapons.LoadTime - weapons.timer;
			slider.maxValue = weapons.LoadTime;
		} else {
			slider.maxValue = weapons.UnloadTime;
			slider.value = weapons.timer;
		}
	}
}
