using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04_ank352
{
  public class MoveForward : MonoBehaviour {

      public float speed = 10;
      public bool easingMovement = true;
      private bool isMoving = false;
      private float currentSpeed = 0.0f;
      private float bounds = 60f;

  	// Use this for initialization
  	void Start () {

  	}

  	// Update is called once per frame
  	void Update () {
        inBounds(transform.position);

        if (Input.GetMouseButton(0)) {
            isMoving = true;

            if (easingMovement)
            {
                // accelerate to speed
                currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime);   //currentSpeed + (.01f * speed);
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward*currentSpeed * Time.deltaTime);

            }
            else
            {
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * speed * Time.deltaTime);
            }
        } else if (isMoving && easingMovement) {
            // decelerate
            currentSpeed = currentSpeed - (.01f * speed);
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            transform.Translate(forward*currentSpeed * Time.deltaTime);
            if (currentSpeed <= 0)
              isMoving = false;
        }
  	   }
       Vector3 inBounds(Vector3 currentPosition) {
         // Debug.Log(currentPosition);
         if (currentPosition.x > bounds) {
           currentPosition.x = bounds;
           Debug.Log(true);
         }

         if (currentPosition.z > bounds)
          currentPosition.z = bounds;

         if (currentPosition.x < -bounds)
          currentPosition.x = -bounds;

         if (currentPosition.z < -bounds)
          currentPosition.z = -bounds;

          return currentPosition;
       }
  }
}
