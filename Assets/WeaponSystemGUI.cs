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

		slider.value = weapons.timer;
	}
}
