using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_cc5341
{
    public class move_ball : MonoBehaviour
    {

        public bool active = false; 


        Rigidbody ballRB;

        void Start()
        {
            ballRB = GetComponent<Rigidbody>();
        }

        void Update()
        {
            float y = transform.position.y;
            float x = transform.position.x;
            float z = transform.position.z;

            print(y);
            if (y < -8.5)
            {
           
                transform.parent = null;
                ballRB.isKinematic = false;

            }
            if (y > 8.5)
            {
             
                transform.parent = null;
                ballRB.isKinematic = false;

            }
            if (x < -8.5)
            {
             
             
                transform.parent = null;
                ballRB.isKinematic = false;

            }
            if (x > 8.5)
            {
             
                transform.parent = null;
                ballRB.isKinematic = false;

            }
        }

        public void PickUpAndMoveBall()
        {
            if (active)
            {  
                active = false;
                transform.parent = null;
                ballRB.isKinematic = false;
            }
            else
            {   
                
                active = true;
                ballRB.isKinematic = true;
                transform.parent = Camera.main.transform;
             

            }
        }
    }
}