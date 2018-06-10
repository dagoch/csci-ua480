using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_Assignment01
{
    class UFOController : MonoBehaviour
    {
        public float speedRotate;
        public float speedDrop;
        public float UFOxPos;
        public float UFOyPos;
        public float UFOzPos;
        private float height;


        void Start()
        {
            speedRotate = 10f;
            speedDrop = 2f;
            height = 10f;
        }

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speedRotate);
            transform.position = new Vector3(UFOxPos, UFOyPos + ( Mathf.Sin( Time.time * speedDrop) * height) , UFOzPos);
        }
    }
}