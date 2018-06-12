using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used the code from the following links to help :D
// https://answers.unity.com/questions/548794/how-to-move-a-camera-only-using-the-arrow-keys.html
// https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996

namespace mhp327_Assignment02
{
    public class MovingCamera : MonoBehaviour
    {

        //public variable controlling how fast the player moves
        public float speed = 5.0f;

        //public variable controlling how sensitive the camera is
        public float camSens = 0.25f;

        //private variable which is the starting point of reference for the mouse. 255, 255, 255 is aruond the middle of the screen
        private Vector3 lastMouse = new Vector3(255, 255, 255);


        void Update()
        {

            //Mouse camera movement    

            //gets the new movement of the mouse
            lastMouse = Input.mousePosition - lastMouse;

            //creates a new vector which multiplies the movement of the mouse in the x and y coordinates by how sensitive we set the camera to
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);

            //creates a new vector which moves the transform of the camera by the lastMouse x and y coordinates
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);

            //sets the transform of the camera (or whatever this script is attached to) to lastMouse
            transform.eulerAngles = lastMouse;

            //lastMouse now becomes the new input of mousePosition
            lastMouse = Input.mousePosition;


            //Keyboard commands

            //First we get the vector3 from GetBaseInput which tells us which key was pressed
            Vector3 p = GetBaseInput();

            //we then multiply the input by the speed
            p = p * speed;

            //we then multiply this vector by Time.deltaTime to make our script frame rate independent 
            p = p * Time.deltaTime;

            //and finally move the transform of the camera in the direction and distance of p
            transform.Translate(p);


            //If the position of the camera is greater than or less than 1.5 then set the y position to 1.5
            if (transform.position.y <= 1.5f || transform.position.y >= 1.5f){
                Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = new Vector3(temp.x, 1.5f, temp.z);
            }

        }

        //returns 1 or -1 in a vector3 depending on what key is pressed, and then 0 if no key was pressed
        private Vector3 GetBaseInput()
        {
            Vector3 p_Velocity = new Vector3();
            if (Input.GetKey(KeyCode.UpArrow))
            {
                p_Velocity += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                p_Velocity += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                p_Velocity += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                p_Velocity += new Vector3(1, 0, 0);
            }
            return p_Velocity;
        }
    }
}

