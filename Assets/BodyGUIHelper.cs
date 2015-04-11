using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BodyGUIHelper : MonoBehaviour {

	public Slider Swedishness;
	private GameManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager> ();
	}

	private void SetSwedishness() {
		Swedishness.value = manager.Swedishness;
		Swedishness.maxValue = manager.MaxSwedishness;
	}
	
	// Update is called once per frame
	void Update () {
		SetSwedishness ();
	}
}
