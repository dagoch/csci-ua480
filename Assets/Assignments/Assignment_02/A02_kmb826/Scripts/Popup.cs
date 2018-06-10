using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The following script is meant to activate a text popup when two specified objects are within
 * a certain distance of each other.
 */ 
namespace kmb826_assignment02
{
    public class Popup : MonoBehaviour
    {

        private float distance; // varaible to hold value of distance between two objects
        public float desired_distance = 10f; // when distance < desired_distance, the popup will show
        public GameObject obj; // object that we want distance between
        public GameObject truck; // vehicle that we want distance between the object
        private MeshRenderer text_mesh; // Renderer for text

        private void Start()
        {
            text_mesh = gameObject.GetComponent<MeshRenderer>();
        }
        void Update()
        {
            distance = Vector3.Distance(obj.transform.position, truck.transform.position);

            if (distance < desired_distance)
            {
                //If less than specified desired distance create popup
                text_mesh.enabled = true;
            }
            else
            {
                //do not create popup
                text_mesh.enabled = false;
            }
        }
    }
}
