using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rmh410.A01 {

public class SlideAlong : MonoBehaviour {

	public int state = -1;
	public GameObject atom1;
	public GameObject atom2;
	private Vector3 dest1 = new Vector3(-7,0,0);
	private Vector3 dest2 = new Vector3(7,0,0);
	public float pulseTimestamp = 0f;
	public float pulseDuration = 2f;
	private float bondDist = 4f;
	private float speed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if contracting
		if (state == -1) {
			// move towards the center
			atom1.transform.position = Vector3.MoveTowards(atom1.transform.position, Vector3.zero, speed * Time.deltaTime);
			atom2.transform.position = Vector3.MoveTowards(atom2.transform.position, Vector3.zero, speed * Time.deltaTime);
			// check if we should switch to pulse
			if (atom1.transform.position.x > bondDist/-2 && atom2.transform.position.x < bondDist/2) {
				state = 0;
				this.pulseTimestamp = Time.fixedTime;
			}
		}

		// if pulsing
		if (state == 0) {
			// check if we should switch to expanding
			if (Time.fixedTime - pulseTimestamp > pulseDuration) {
				this.state = 1;
			}
		}

		// if expanding
		if (state == 1) {
			// move outwards
			atom1.transform.position = Vector3.MoveTowards(atom1.transform.position, dest1, speed * Time.deltaTime);
			atom2.transform.position = Vector3.MoveTowards(atom2.transform.position, dest2, speed * Time.deltaTime);
			// check if we should switch to contracting
			if (atom1.transform.position.x <= dest1.x && atom2.transform.position.x >= dest2.x) {
				this.state = -1;
			}
		}
		
	}
}
}
