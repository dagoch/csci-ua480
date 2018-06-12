using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A01 
{
    public class MoveSphere : MonoBehaviour
    {
        public float xpos;
        public float zpos;
        public float speed;
        public float height;

        void Start()
        {
            xpos = 0;
            zpos = 0;
            speed = 3;
            height = 3;
        }

        void Update()
        {
            transform.localPosition = new Vector3(xpos, Mathf.Sin(Time.time * speed) * height, zpos);
        }
    }
}

