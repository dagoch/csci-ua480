using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used this tutorial to help write this code https://unity3d.com/learn/tutorials/topics/physics/colliders-triggers
namespace mhp327_Assignment02
{
    public class ByeBumpers : MonoBehaviour
    {

         void OnTriggerStay (Collider other)
        {
            //once the camera enters the collider of any of the bumpers
            //if the user right clicks we simply destroy the bumpers
            //and activate the harder version
            if (Input.GetMouseButtonDown(1) ){

                Destroy(gameObject);

            }

        }
    }
}
