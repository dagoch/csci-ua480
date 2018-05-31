using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826
{
    public class ObjectColor : MonoBehaviour
    {
        public float red, green, blue, alpha;

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
