using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A01 
{
    public class Rotate : MonoBehaviour 
    {
        
        public float speed = 100.0f;

        void Start()
        {
           
        }

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
