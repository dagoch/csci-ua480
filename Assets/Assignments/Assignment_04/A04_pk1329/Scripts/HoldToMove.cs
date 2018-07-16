using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A04
{
    public class HoldToMove : MonoBehaviour
    {

        // Instantiate Variables
        [Tooltip("Moving speed per second")]
        public float TargetMovingSpeed;

        private float _easingMovementTime = 1.0f;

        private float _currentMovingSpeed = 0.0f;

        private bool _buttonDown = false;

        Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = Camera.main.GetComponent<Rigidbody>();
        }

        private IEnumerator EaseSpeedToTarget(float target)
        {
            // Accelerate or decelerate
            float t = 0.0f;
            float diff = target - _currentMovingSpeed;
            while (t < _easingMovementTime)
            {
                t += Time.smoothDeltaTime;
                _currentMovingSpeed = target - diff * (1.0f - t / _easingMovementTime);
                yield return null;
            }
            _currentMovingSpeed = target;
        }


        // Update is called once per frame
        void Update()
        {
            // Run only when the button is clicked
            if (Input.GetMouseButton(0))
            {

                // When button is clicked, change buttondown state to true
                if (!_buttonDown)
                {
                    // User just pressed the button
                    _buttonDown = true;
                    StartCoroutine(EaseSpeedToTarget(TargetMovingSpeed));
                    
                }
            }

            // If button isn't pressed, change button down state to false
            else if (_buttonDown)
            {
                //User just released the button
                _buttonDown = false;
                StartCoroutine(EaseSpeedToTarget(0.0f));
            }

            if (!Mathf.Approximately(_currentMovingSpeed, 0.0f))
            {
                
                Vector3 camDir = Camera.main.transform.forward;
                camDir.y = 0.0f;

                // Move player forward with appropriate acceleration or deceleration
                transform.Translate(camDir.normalized * _currentMovingSpeed * Time.deltaTime, Space.World);
            }


        }

    }
}