using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SharedGUIHelper : MonoBehaviour {

	public Slider Swedishness;
	public Slider Life;
	private GameManager manager;

	public HealthComponent Tank;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager> ();

	}

	private void SetSwedishness() {
		//Swedishness.maxValue = manager.MaxSwedishness;
		Swedishness.value = manager.Swedishness;
	}
	
	// Update is called once per frame
	void Update () {
		Life.value = Tank.Health;
		Life.maxValue = Tank._MAXHEALTH;
		SetSwedishness ();
	}
}
