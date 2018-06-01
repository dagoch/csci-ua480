using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour {
    public Vector3 beginning;
    public Vector3 end;
    float counter;
    public float speed;
	// Use this for initialization
	void Start () {
        beginning = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
    counter += speed * Time.deltaTime;

    transform.position = Vector3.Lerp(beginning, end, counter);
	}
}
