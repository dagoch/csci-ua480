using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class ObjectColor : MonoBehaviour
    {
        public float red, green, blue, alpha;

        // Generic script to manipulate the color of any GameObject desired
        void Start()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
        }
    }
}
