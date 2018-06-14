using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to shoot object from cannon on top of vehicle

namespace kmb826_assignment02
{
    public class Cannon : MonoBehaviour
    {

        public Rigidbody projectile;
        private readonly float pwr = 50.0f;

        void Update()
        {
            //If user is pressing Space bar
            if (Input.GetKey(KeyCode.Space))
            {
                Rigidbody projectile_clone = Instantiate(projectile, transform.position, transform.rotation); // object to shoot out of cannon
                projectile_clone.velocity = transform.TransformDirection(Vector3.forward * pwr); // shoot object forward

            }
        }


    }
}
