using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a simple script used on the projectile object that is shot by the camera. 
 * 
*/ 

namespace kmb826_assignment02
{
    public class Projectile : MonoBehaviour
    {

        void Start()
        {
            //Destroy projectile after 3 seconds of being shot
            Destroy(gameObject, 3f);
        }

        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            // If projectile hits a ball, then it destroys the ball
            if (collision.gameObject.tag == "ball")
            {
                //Debug.Log("Projectile Hit!");
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
