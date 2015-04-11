using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SharedGUIHelper : MonoBehaviour {

	public Slider Swedishness;
	private GameManager manager;

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
		SetSwedishness ();
	}
}
