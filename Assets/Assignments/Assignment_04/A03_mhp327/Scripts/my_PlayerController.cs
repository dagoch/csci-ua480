using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This unity forum page helped me
//https://answers.unity.com/questions/29751/gradually-moving-an-object-up-to-speed-rather-then.html

namespace mhp327_A04
{
    public class my_PlayerController : MonoBehaviour
    {
        public static my_PlayerController Instance;
        public float rayLength = 10.0f;

        private float speed = 0.0f;
        public float MaxSpeed = 6.0f;
        public float Acceleration = 2.0f;
        public float Deceleration = 2.0f;

        public bool easingMovement = false;

        private bool isMoving = false;
        private float currentSpeed = 0.0f;



        private void Awake()
        {
            //Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        public void Translate(Vector3 translation)
        {
            transform.Translate(translation, Space.World);
        }

        public void MoveToPosition(Vector3 des, float time)
        {
            StopAllCoroutines();
            des.y = transform.position.y;
            StartCoroutine(MoveToPositionGradually(des, time));
        }

        private IEnumerator MoveToPositionGradually(Vector3 des, float time)
        {
            float t = 0.0f;
            Vector3 initialPos = transform.position;
            while (t < time)
            {
                t += Time.smoothDeltaTime;
                transform.position = initialPos + (des - initialPos) * Mathf.Lerp(0.0f, 1.0f, t / time);
                yield return null;
            }
            transform.position = des;
        }


        private void Update()
        {
             
            if (Input.GetMouseButton(0))
            {

                //if the screen is tapped raycast from the main camera into the scene

                Ray lookingRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hit;

                //if the ray hits the plane within 10 meters teleport to where 
                //the ray and the plane intersect
                if ( Physics.Raycast(lookingRay, out hit, rayLength))
                {
                    //if statement to make sure teleport is only once
                    //and not continuous
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 newPos = hit.point;
                        newPos.y = 1.5f;

                        transform.position = newPos;


                    }

                }

                //if the ray does not intersect the plane
                //move it accelerate it forward to max speed
                else
                {
                    
                    if (speed < MaxSpeed){
                        speed = speed + Acceleration * Time.deltaTime;
                    }
                    else if (speed >= MaxSpeed ){
                        speed = 5.0f;
                    }

                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * speed * Time.deltaTime);

                }
           
                }

                //if no button is being pressed down and if the player is 
                //moving then decelerate
            else{
                
                if (speed > Deceleration * Time.deltaTime)
                {
                    speed = speed - Deceleration * Time.deltaTime;
                }
                else if (speed < (-1.0f) * Deceleration * Time.deltaTime)
                {
                    speed = speed + Deceleration * Time.deltaTime;
                }
                else
                {
                    speed = 0;
                }

                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * speed * Time.deltaTime);

            }


            }
        }
    }

