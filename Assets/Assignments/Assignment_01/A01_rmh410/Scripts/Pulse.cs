using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rmh410.A01 {

public class Pulse : MonoBehaviour {

	public SlideAlong stateManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if in pulse mode
		if (stateManager.state == 0) {
			float pulseTime = Time.fixedTime - stateManager.pulseTimestamp;
			float inc = 0;
			// if growing
			if ((pulseTime >= 0f && pulseTime < 0.5f) || (pulseTime >= 1f && pulseTime < 1.5f)) {
				inc = Time.deltaTime/(stateManager.pulseDuration/4);
				transform.localScale = transform.localScale + new Vector3(inc,inc,inc);
			}
			else {
				inc = Time.deltaTime/(stateManager.pulseDuration/4);
				transform.localScale = transform.localScale - new Vector3(inc,inc,inc);
			}
		}
		else {
			transform.localScale = new Vector3(1,1,1);
		}
	}
}
}