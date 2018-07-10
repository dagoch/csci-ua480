using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace lga238 {
public class Accelerate : MonoBehaviour {
	public float speed;
	public float currentSpeed;
	private bool moving = false;
	private bool easingMovement = false;

	void Start () {
		speed = 8.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0)){
			moving = true;

			if (easingMovement){
				//accelarate
				currentSpeed = currentSpeed + (0.1f * speed);
			}
			else{
				transform.position+= Camera.main.transform.forward * speed * Time.deltaTime;
			}
		}


		else if(moving){
			//decellerate
		}
	}
}
}
