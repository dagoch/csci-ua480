using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment02
{
    public class Cannon : MonoBehaviour
    {

        public Rigidbody projectile;
        private readonly float pwr = 50.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.Space))
            {
                Rigidbody projectile_clone = Instantiate(projectile, transform.position, transform.rotation);
                projectile_clone.velocity = transform.TransformDirection(Vector3.forward * pwr);

            }
        }


    }
}
