using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment02
{
    public class ShootFromCamera : MonoBehaviour
    {

        private Vector3 mouse_coord;
        VectorDirection vector_direction = new VectorDirection();
        private GameObject empty_object;
        public Rigidbody projectile;

        private float pwr = 100f;

        private void Start()
        {
            empty_object = new GameObject("empty_object");
        }

        void Update()
        {
            mouse_coord = new Vector3(Input.mousePosition.x - (Screen.width / 2f), Input.mousePosition.y - (Screen.height / 2f), 0f);
            StartCoroutine("GetVectorDirection");
            
            // If left mouse button is clicked, then a Raycast will be activated
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit shot;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Mouse cursor dictates direction of shot

                if (Physics.Raycast(ray, out shot))
                {
                    // Shoot object along with raycast
                    Rigidbody projectile_clone = Instantiate(projectile, ray.origin, Quaternion.identity);
                    projectile_clone.velocity = transform.TransformDirection(empty_object.transform.forward * pwr);

                    // If ball is hit, then it will be destoryed
                    if (shot.transform.gameObject.tag == "ball")
                    {
                        Debug.Log("Ball spotted!");
                        Destroy(shot.transform.gameObject);
                    }

                }

            }
        }

        IEnumerator GetVectorDirection()
        {
            empty_object.transform.forward = vector_direction.Direction(mouse_coord, 1.3f);
            //transform.localEulerAngles = empty_object.transform.eulerAngles;
            yield return empty_object;
        }
    }
}
