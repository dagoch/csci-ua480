using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	public float sensitivity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float z = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");
		Vector3 vec = new Vector3(x,0,z);
		vec = vec * sensitivity;
		transform.Translate(vec);
	}
}
