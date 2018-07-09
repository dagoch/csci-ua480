using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0,Mathf.Sin(Time.time), Mathf.Cos(Time.time));
	}
}
