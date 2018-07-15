using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lga238 {
public class MoveForward : MonoBehaviour {

	// Use this for initialization
	public float speed;

	void Start () {
		speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0)){
			transform.position+= Camera.main.transform.forward * speed * Time.deltaTime;
		}
	}
}
}
