using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02jjo350 {
    public class CameraController : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        public float speed = 5.0f;
        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            transform.Translate(moveX, 0, moveZ); 

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Rotate(new Vector3(mouseY * -1, mouseX, 0) * speed);

            if (Input.GetKey("escape")) {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

}
