using UnityEngine;
using System.Collections;

public class TurretControll2 : MonoBehaviour {

	public SphereManipulator falcon;

	public Transform target;
	public float speed;

	public Transform pipe;

	public float ForceScale;

	public Rigidbody body;

	public AudioSource a ;

	public float ascale;

	// Use this for initialization
	void Start () {
	
	}

	float ClampAngle(float angle, float min, float max) {
		
		if (angle<90 || angle>270){       // if angle in the critic region...
			if (angle>180) angle -= 360;  // convert all angles to -180..+180
			if (max>180) max -= 360;
			if (min>180) min -= 360;
		}    
		angle = Mathf.Clamp(angle, min, max);
		if (angle<0) angle += 360;  // if angle negative, convert to 0..360
		return angle;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( target.transform.position- transform.position, new Vector3(0,1,0)), speed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position, new Vector3 (0, 1, 0)), speed * Time.deltaTime);


		Vector3 angle = transform.localEulerAngles;
		angle.x = ClampAngle(angle.x, -30.0f, 10.0f);
		transform.localEulerAngles = angle;

		var v = target.localPosition;
		v.z = -v.z;

		if (v.magnitude > 0.4f)
			a.volume = v.magnitude * ascale;
		else
			a.volume = 0;

		falcon.TurretForce = ForceScale * v;

		var p = target.localPosition;
		p.z = 0;
		target.localPosition = p;

	}
}
