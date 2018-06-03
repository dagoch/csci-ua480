using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from https://answers.unity.com/questions/754633/how-to-move-an-object-left-and-righ-looping.html

namespace wg698.A01
{
    public class Move : MonoBehaviour
    {
        public float speed = 2.0f;
        public float amount = 1.5f;
        public float offset = 0;
        private Vector3 start;

        void Start()
        {
            start = transform.position;
        }

        void Update()
        {
            Vector3 vector = start;
            vector.x += amount * Mathf.Sin(Time.time * speed);
            transform.position = vector;
        }
    
    }
}

