using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used this very helpful tutorial :) https://unity3d.com/learn/tutorials/topics/scripting/instantiate

namespace mhp327_Assignment02
{
    public class ShootsBall : MonoBehaviour
    {
        //ball to roll
        public Rigidbody ball;
        //position to roll it from
        public Transform rollPosition;
        //check to make sure player clicked down
        private bool checkOne = false;

        void Update()
        {
            //using this extra checkOne bool helps prevent instantiation
            //of a ton of balls
            if (Input.GetMouseButtonDown(0) || checkOne){

                checkOne = true;
                if (Input.GetMouseButtonUp(0) && checkOne)
                {
                    //if the mouse is pressed down and released then we instantiate
                    //and apply force forward
                    Rigidbody ballInstance;
                    ballInstance = Instantiate(ball, rollPosition.position, rollPosition.rotation) as Rigidbody;
                    ballInstance.AddForce(rollPosition.forward * 1500f);

                    //we now must set this variable to false again for the next roll
                    checkOne = false;

                }
            }

        }
    }
}