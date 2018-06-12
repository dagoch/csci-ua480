using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to wag the tail of dog in scene

namespace kmb826_assignment02
{
    public class WagTail : MonoBehaviour
    {

        private readonly float speed = 10.0f;
        private readonly float wagAngle = 30.0f;

        void Update()
        {
            transform.rotation = Quaternion.Euler(wagAngle * Mathf.Sin(Time.time * speed), wagAngle * Mathf.Sin(Time.time * speed), wagAngle * Mathf.Sin(Time.time * speed));
        }
    }
}
