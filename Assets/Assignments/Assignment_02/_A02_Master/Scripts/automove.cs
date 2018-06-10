using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automove : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       
        Vector3 movement = new Vector3(0, 0.0f, speed);

        rb.AddRelativeForce(movement);
	}
}
