using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIUtilities : MonoBehaviour {

	public Slider screenSlider;

	public DualMonitorManager dualMonitorManager;

	void Start() {
		dualMonitorManager.SetScreenSplit (0.562f);
	}

	public void UpdateScreen() {
		dualMonitorManager.SetScreenSplit (screenSlider.value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
