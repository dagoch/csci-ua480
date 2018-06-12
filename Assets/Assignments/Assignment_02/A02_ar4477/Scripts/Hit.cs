using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ar4477.A02 
{
    public class Hit : MonoBehaviour
    {
        // declare variables
        public GameObject target;
        Renderer r;

        void Start()
        {
            // set target to the rim
            target = GameObject.Find("Rim");
            r = target.transform.GetComponent<Renderer>();
        }

        void Update()
        {
            
        }

        // code based on a Unity forum post
        void OnCollisionEnter(Collision col)
        {
            // check to see if object collided with is the rim
            if (col.gameObject.name == "Rim")
            {
                // change color upon contact and then destroy target
                r.material.color = Color.red;
                Destroy(target, 1.5f);
            }
        }

    } 
}

