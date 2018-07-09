using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02zs967
{
    public class FirstPersonMover : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            //Vector3 position = transform.position;
            //position.x += moveX;
            //position.z += moveZ;

            transform.Translate(moveX, 0, moveZ);
        }
    }
}