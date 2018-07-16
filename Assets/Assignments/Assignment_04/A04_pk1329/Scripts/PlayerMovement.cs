using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A04
{
    public class PlayerMovement : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;

            // When button is pressed, run this code.
            if (Input.GetMouseButton(0))
            {

                // Use Raycast
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50f))
                {
                    // Run only if the reticle is looking at the plane.
                    if (hit.collider.name == "Plane")
                    {
                        // Run only if the reticle's hit point is within 10 units
                        if (hit.distance <= 10)
                        {
                            // Teleport to where the Reticle is looking.
                            transform.position = new Vector3(hit.point.x, hit.point.y + 2.0f, hit.point.z);
                        }
                    }
                    else 
                    {
                        
                    }
                }
            }
        }
    }
}
