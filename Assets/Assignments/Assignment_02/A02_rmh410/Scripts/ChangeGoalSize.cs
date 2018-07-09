using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGoalSize : MonoBehaviour {
	public GameObject goal;
	public float sizeFactor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			if(goal.transform.localScale.x == 1.0f) {
				goal.transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);
			}
			else {
				goal.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
		}
	}
}
