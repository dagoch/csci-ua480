using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A02
{
    public class FirstPersonMove : MonoBehaviour
    {

        void Start()
        {

        }

        void Update()
        {
            // get user x and z positions
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // move depending on arrow keys
            transform.Translate(moveX, 0, moveZ);
        }

    }
}