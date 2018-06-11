using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic script to give color to specified game object
namespace kmb826_assignment02
{
    public class Color : MonoBehaviour
    {
        public float red = 0f, green = 1f, blue = 0f, alpha = 1f;
    
        void Start()
        {
            gameObject.GetComponent<Renderer>().material.color = new UnityEngine.Color(red, green, blue, alpha);
        }
    }
}
