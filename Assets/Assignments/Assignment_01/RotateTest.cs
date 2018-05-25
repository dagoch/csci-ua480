using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    //properties
    //Transform transform
    //GameObject gameObject
    //Vector3
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //calculate rotation
        //Debug.Log(transform.eulerAngles);
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
        
	}
}
