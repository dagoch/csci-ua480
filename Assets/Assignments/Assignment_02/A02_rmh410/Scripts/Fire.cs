using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public GameObject ball;
	public float power;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			GameObject fired = Instantiate(ball, ball.transform.position, Quaternion.identity);
			Rigidbody rb = fired.GetComponent<Rigidbody>();
			rb.transform.position = transform.position;
			Vector3 cameraDir = Camera.main.transform.forward;
			rb.AddForce(cameraDir*power);
		}
	}
}
