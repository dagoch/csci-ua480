using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_forward : MonoBehaviour {

    Rigidbody ballRB;

	// Use this for initialization
	void Start () {
        ballRB = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        print(Camera.main.transform.localRotation.x);
        if (isMoving)
        {
            Vector3 newVector =  new Vector3(ballRB.transform.position.x, ballRB.transform.position.y, 100 * Camera.main.transform.localRotation.x);

            ballRB.transform.position = newVector;
        }
	}

    bool isMoving = false;

    public void move()
    {
        print("move");
        isMoving = true;
        ballRB.isKinematic = true;
    }
}
