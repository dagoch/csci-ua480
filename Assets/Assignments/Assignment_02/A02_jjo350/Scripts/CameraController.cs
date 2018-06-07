using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02jjo350 {
    public class CameraController : MonoBehaviour
    {
        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
        }
        public float xSens = 5.0f;
        public float ySens = 5.0f;
        public float movementSpeed = 10.0f;

        private float mouseX;
        private float mouseY;


        // Update is called once per frame
        void Update() {

            /*
             * I had 99% of this before, but I didn't think to maintain the mouseX/Y as 
             * private variables.
             * I found out about that here:
             * https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
             */
            mouseX += Input.GetAxis("Mouse X") * xSens;
            mouseY -= Input.GetAxis("Mouse Y") * ySens;

            transform.eulerAngles = new Vector3(mouseY, mouseX, 0);

            if (Input.GetKey("escape")) {
                Cursor.lockState = CursorLockMode.None;
            }

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 deltaMove = new Vector3(moveX, 0, moveZ) * Time.deltaTime * movementSpeed;
            deltaMove = transform.rotation * deltaMove;
            transform.position = transform.position + deltaMove;
        }
    }

}
