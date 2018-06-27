using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A02 
{
    public class Move : MonoBehaviour
    {
        // declare variables
        public float xpos;
        bool right;
        bool left;
        public float speed;
        Renderer r;

        void Start()
        {
            // set variables to begin
            xpos = transform.position.x;
            right = true;
            left = false;
            speed = 1f;
            r = GetComponent<Renderer>();
        }

        void Update()
        {
            // check if target is in sight, and if it is, change its speed
            if (r.isVisible)
            {
                // determine which key is pressed to change speed
                if (Input.GetKeyDown(KeyCode.F))
                {
                    speed = 2.5f;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    speed = .5f;
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    speed = 1f;
                }
            }

            // determine whether to go left or right based on x position
            if (right)
            {
                xpos += speed;
            }
            if (left)
            {
                xpos -= speed;
            }
            if (xpos >= 60)
            {
                right = false;
                left = true;
            }
            if (xpos <= -107)
            {
                right = true;
                left = false;
            }

            // update position
            transform.localPosition = new Vector3(xpos, transform.position.y, transform.position.z);

        }

    }
}

