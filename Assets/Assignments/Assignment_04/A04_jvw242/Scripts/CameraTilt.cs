using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is based off the code implemented in class.

namespace A04_jvw2421
{
    [RequireComponent(typeof(Camera))]
    public class CameraTilt : MonoBehaviour
    {
        public float TiltingSpeed = 0.05f;

        public float ThresholdAngle
        {
            get {
                return angle;
            }
            set {
                angle = value;
                magnitude = Mathf.Cos(ThresholdAngle * Mathf.Deg2Rad);
            }
        }

        private void Start()
        {
            magnitude = Mathf.Cos(ThresholdAngle * Mathf.Deg2Rad);
        }

        [SerializeField]

        private float angle = 30f;
        private float magnitude;


        void LateUpdate()
        {
            Vector3 translation = transform.up;
            translation.y = 0;
            if (translation.magnitude > magnitude)
            {
                PlayerController.Object.Translate(translation * TiltingSpeed);
            }
        }
    }
}