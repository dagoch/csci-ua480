using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment02 
{
    public class BBalls : MonoBehaviour
    {
        private int count = 0;
        private static int ball_count = 0;
        private Rigidbody ball;
        public GameObject area;
        private bool collisionDetected = false;

        // Use this for initialization
        void Start()
        {
            ball = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            // Want to instantiate new ball after some bounces have occurred
            if (collisionDetected && count > 5)
            {
                if (ball.position.y > 5) //Instatiate ball while it is in the air
                {
                    Rigidbody newBall = Instantiate(ball); // Instantiate new ball
                    ball_count++;
                    Debug.Log("Ball Count: " + ball_count);
                    newBall.AddExplosionForce(200f, Vector3.forward, 500f); // Add force to help the ball bounce
                    collisionDetected = false; // reset collision boolean to false
                    count = 0; // reset count to zero
                }

                // Simply to help manage the number of balls in the playing area, whenever the number hits 200, 50 will be destroyed
                if (ball_count > 200)
                {
                    GameObject[] obj_array = obj_array = GameObject.FindGameObjectsWithTag("ball"); // Make and array of ball gameObjects
                    for (int i = 0; i < 50; i++)
                    {
                        Destroy(obj_array[i]); // iterate through and destroy
                        ball_count--; // decrement count varable
                        Debug.Log("Ball Count: " + ball_count);
                    }
                }
            }
        }

        // This function keeps track of ball bounces
        // Each time the ball collides with playing area the counter is incremented by 1
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Playing Area")
            {
                collisionDetected = true;
                count++;
            }
        }

    }
}

