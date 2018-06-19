using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A03Examples
{
    public class ScaleSliderController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        public float MaxAngle = 45.0f;

        private Slider _slider;
        private float _intialCameraRotationY;
        private Vector3 _initialLocalScale;
        private bool _buttonReleased;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            //The initial value is 0.5 for 1*1*1 scale in transform
            _slider.value = 0.5f;
        }

        private void OnEnable()
        {
            if (MenuCanvasController.Instance == null)
            {
                return;
            }

            _intialCameraRotationY = Camera.main.transform.rotation.eulerAngles.y;
            ControllingTransform = MenuCanvasController.Instance.ControllingObject.transform;
            _initialLocalScale = ControllingTransform.localScale;
            _buttonReleased = false;
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            _initialLocalScale = Vector3.one;
        }

        private float GetCurrentDeltaRotationFactor()
        {
            float currentCameraRotationY;
            if (Camera.main.transform.rotation.eulerAngles.y > 180.0f)
            {
                currentCameraRotationY = Camera.main.transform.rotation.eulerAngles.y - 360.0f;
            }
            else
            {
                currentCameraRotationY = Camera.main.transform.rotation.eulerAngles.y;
            }
            float ClampedDeltaAngle = Mathf.Clamp((currentCameraRotationY - _intialCameraRotationY), -MaxAngle, MaxAngle);
            return ClampedDeltaAngle / (MaxAngle * 2) + 0.5f;
        }

        private bool CheckIfClickButton()
        {
            if (Input.GetMouseButton(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void LateUpdate()
        {
            if (ControllingTransform != null)
            {
                float currenDeltaRotationFactor = GetCurrentDeltaRotationFactor();
                _slider.value = currenDeltaRotationFactor;
                ControllingTransform.localScale = _initialLocalScale * Mathf.Lerp(0.5f, 1.5f, currenDeltaRotationFactor);

                if (CheckIfClickButton())
                {
                    if (_buttonReleased)
                    {
                        _buttonReleased = false;
                        MenuCanvasController.Instance.Hide();
                    }
                }
                else
                {
                    if (!_buttonReleased)
                    {
                        _buttonReleased = true;
                    }
                }
            }

        }
    }
}
