using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class ShootBall : MonoBehaviour
    {
        public float strength;

        public GameObject ball;

        void Update()
        {

            if ( Input.GetMouseButtonDown(0) )
            {
                //get the direction of the pointer
                Vector3 pointerDirection = Camera.main.ScreenPointToRay(Input.mousePosition).direction;

                //Debug.Log("Ball Direction: " + pointerDirection);

                //adjust the position of the ball so that it is slightly in front of and above the character's collider
                Vector3 ballPosition = transform.position + pointerDirection;
                ballPosition.y += .5f;

                //instantiate ball
                GameObject b = Instantiate(ball, ballPosition , transform.rotation);

                //get rigid body, and add force in direction of pointer
                Rigidbody rb = b.GetComponent<Rigidbody>();
                Vector3 force = pointerDirection * strength;
                //Debug.Log("Imparting Force: " + force);
                rb.AddForce(force);
            }

        }
    }
}
