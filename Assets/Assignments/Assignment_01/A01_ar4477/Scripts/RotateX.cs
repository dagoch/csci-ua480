using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A01 
{
    public class RotateX : MonoBehaviour 
    {

        public float speed = 100.0f;

        void Start()
        {
          
        }

        void Update()
        {
            //transform.Rotate(Vector3.right, Time.deltaTime);
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
