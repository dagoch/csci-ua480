using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_Assignment01
{
    public class ArmsRotating : MonoBehaviour
    {

        public float ArmSpeed;
        public float ArmDirection;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.right * Time.deltaTime * ArmSpeed * ArmDirection);
        }
    }
}