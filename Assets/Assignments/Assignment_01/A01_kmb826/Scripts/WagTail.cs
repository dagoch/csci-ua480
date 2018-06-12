using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
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
