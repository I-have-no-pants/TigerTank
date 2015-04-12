using UnityEngine;
using System.Collections;

public class DualMonitorManager : MonoBehaviour {

	public Camera cam1;
	public Camera cam1_overlay;
	public Camera cam2;

	// Use this for initialization
	void Start () {
		Screen.SetResolution(3840, 1080, false);

	}

	public void SetScreenSplit(float camS1) {

		var rect = cam1.rect;
		rect.width = camS1;
		cam1.rect = rect;

		//cam1_overlay.rect = rect;

		rect = cam2.rect;
		rect.width = 1f-camS1;
		rect.x = camS1;
		cam2.rect = rect;

	}
}
