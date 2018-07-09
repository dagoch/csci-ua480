using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A02{
public class MoveCamera : MonoBehaviour {

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis("Vertical") * speed;
		float moveY = Input.GetAxis("Horizontal") * speed;
		moveX *= Time.deltaTime;
		moveY *= Time.deltaTime;

		transform.Translate(moveY, 0, moveX); 

	}
}
}