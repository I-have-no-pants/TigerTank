using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIUtilities : MonoBehaviour {

	public Slider screenSlider;

	public DualMonitorManager dualMonitorManager;


	public void UpdateScreen() {
		dualMonitorManager.SetScreenSplit (screenSlider.value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
