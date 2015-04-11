using UnityEngine;
using System.Collections;

public class TurretControll2 : MonoBehaviour {

	public SphereManipulator falcon;

	public Transform target;
	public float speed;

	public Transform pipe;

	public float ForceScale;

	public Rigidbody body;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( target.transform.position- transform.position, new Vector3(0,1,0)), speed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position, new Vector3 (0, 1, 0)), speed * Time.deltaTime);

		var v = target.localPosition;
		v.z = -v.z;

		falcon.TurretForce = ForceScale * v;

		var p = target.localPosition;
		p.z = 0;
		target.localPosition = p;

	}
}
