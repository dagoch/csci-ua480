using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment02
{
    /*
     * All code that is commented with "*" was used/modified from:
     * https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
     */
    public class CameraFollowTruck : MonoBehaviour
    {
        //public Camera main;
        //public Camera secondary;

        public GameObject vehicle; 

        private Vector3 offset; // *

        void Start()
        {
            offset = transform.position - vehicle.transform.position; // *
        }

        void Update()
        {
            // Keep the camera always behind the vehicle
            //This accounts for when the vehicle turns left and right
            
                //main.gameObject.SetActive(true);
                //secondary.gameObject.SetActive(false);

                transform.position = vehicle.transform.position + (vehicle.transform.forward * offset.magnitude); // change position relative to vehicle
                                                                                                                  // Raise height of camera above vehicle to give better range of sight
                transform.position = new Vector3(transform.position.x, transform.position.y * 7f, transform.position.z);
                transform.LookAt(vehicle.transform.position); // look at vehicle at all times
                
        }
    }
}
