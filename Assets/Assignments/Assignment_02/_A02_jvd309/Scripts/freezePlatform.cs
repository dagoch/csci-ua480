using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePlatform : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
    void OnCollisionEnter(Collision collision) {
             rb.isKinematic = true;
         }
     }    

