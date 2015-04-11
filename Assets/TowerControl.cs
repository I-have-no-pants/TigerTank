using UnityEngine;
using System.Collections;

public class TowerControl : MonoBehaviour {

	public float maxTowerRotationSpeed = 5.0f;
	private float towerRotationSpeed;

	public float maxBarrelRotationSpeed = 5.0f;
	private float barrelRotationSpeed;

	public float horizontalThreshold = 0.1f;
	public float verticalThreshold = 0.2f;
	public GameObject tip;
	public Camera cam;
	public GameObject tower;
	public GameObject barrel;
	public GameObject barrelJoint;

	private float barrelVerticalRotation = 0.0f;
	public float barrelMaxVerticalRotation = 20.0f;

	const float midpoint = 0.5f; // screen midpoint is 0.5, 0.5 in Viewport Space
	private bool usingFalcon;
	
	void Start ()
	{
		towerRotationSpeed = maxTowerRotationSpeed;
		barrelRotationSpeed = maxBarrelRotationSpeed;
	}
	// Update is called once per frame
	void Update () {

		Vector3 tipPosition = new Vector3(); // Tip position projected on the camera, used for Falcon movement

		if (FalconUnity.getNumFalcons () > 0) {
			usingFalcon = true;
			tipPosition = cam.WorldToViewportPoint (tip.transform.position); 
		}
		else {
			usingFalcon = false;
		}

		// TOWER ROTATION
		float deltaTowerRotationSpeed = towerRotationSpeed * Time.deltaTime;

		if (usingFalcon) {
			if (tipPosition.x > midpoint + horizontalThreshold) {
				tower.transform.Rotate (Vector3.up, deltaTowerRotationSpeed);
			} else if (tipPosition.x < midpoint - horizontalThreshold) {
				tower.transform.Rotate (Vector3.up, -deltaTowerRotationSpeed);
			}
		} 
		else 
		{
			var dir = Input.GetAxis("Horizontal");
			tower.transform.Rotate (Vector3.up, dir*deltaTowerRotationSpeed);
		}

		//BARREL ADJUSTMENT (VERTICAL)
		float deltaBarrelRotationSpeed = barrelRotationSpeed * Time.deltaTime;
		float angle = barrelJoint.transform.localEulerAngles.x;

		if (usingFalcon) {
			if (tipPosition.y > midpoint + verticalThreshold) {// MOVE UP
				barrelJoint.transform.Rotate (-barrelJoint.transform.right, deltaBarrelRotationSpeed, Space.World);

			} else if (tipPosition.y < midpoint - verticalThreshold) {// MOVE DOWN
				barrelJoint.transform.Rotate (barrelJoint.transform.right, deltaBarrelRotationSpeed, Space.World);
			}
		} 
		else  
		{//no falcon
			var dir = Input.GetAxis("Vertical");
			barrelJoint.transform.Rotate (barrelJoint.transform.right, -dir*deltaBarrelRotationSpeed, Space.World);

			if (angle < 70)
			{
				// Rotate back
				barrelJoint.transform.Rotate (barrelJoint.transform.right, dir*deltaBarrelRotationSpeed*2, Space.World);
			}

		}
	}
}