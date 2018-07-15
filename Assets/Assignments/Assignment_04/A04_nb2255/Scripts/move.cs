using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class move : MonoBehaviour
    {
        public float speed = 1;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if ( Input.GetMouseButton(0) )
            {
                //when the mouse button is being pressed
                //Debug.Log("mouse button down!");
                Rigidbody rb = GetComponent<Rigidbody>();
                //get direction of camera
                Vector3 direction = Camera.main.transform.rotation * Vector3.forward * speed;
                //add force in that direction
                rb.AddForce(direction);
            }
        }
    }
}