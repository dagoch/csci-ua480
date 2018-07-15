using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_A04
{
    [RequireComponent(typeof(Camera))]
    public class my_CameraTiltingDetection : MonoBehaviour
    {
        public float TiltingSpeed = 0.05f;

        public float ThresholdAngle
        {
            get
            {
                return _thresholdAngle;
            }
            set
            {
                _thresholdAngle = value;
                _thresholdMagnitude = Mathf.Sin(ThresholdAngle * Mathf.Deg2Rad);
            }
        }

        private void Start()
        {
            _thresholdMagnitude = Mathf.Sin(ThresholdAngle * Mathf.Deg2Rad);
        }

        [Tooltip("If the tilting angle is below the threshold, player will not move")]
        [SerializeField]
        private float _thresholdAngle = 25f;

        private float _thresholdMagnitude;


        // It will be called after the camera is updated
        void LateUpdate()
        {
            Vector3 translation = transform.up;
            translation.y = 0;
            if (translation.magnitude > _thresholdMagnitude)
            {
                my_PlayerController.Instance.Translate(translation * TiltingSpeed);
            }
        }
    }
}
