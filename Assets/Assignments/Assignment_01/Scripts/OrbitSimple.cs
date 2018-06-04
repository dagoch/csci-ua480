using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSimple : MonoBehaviour {

    public Transform centralObject;

    public Rigidbody myBody;


    public float initForce = 100.0f;

    public float dist = 0;
    public float speed;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
        myBody.AddForce(transform.right * initForce);


	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 inward = centralObject.position - transform.position;
        dist = inward.magnitude;
        inward.Normalize(); // get direction only

        myBody.AddForce(inward * 10 / dist);

        speed = myBody.velocity.magnitude;
	}
}
