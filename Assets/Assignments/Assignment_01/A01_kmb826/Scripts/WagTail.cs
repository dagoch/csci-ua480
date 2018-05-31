using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class WagTail : MonoBehaviour
    {

        private float speed = 10.0f;
        private float wagAngle = 30.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.Euler(wagAngle * Mathf.Sin(Time.time * speed), wagAngle * Mathf.Sin(Time.time * speed), wagAngle * Mathf.Sin(Time.time * speed));
        }
    }
}
