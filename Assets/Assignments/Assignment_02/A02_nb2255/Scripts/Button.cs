using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class Button : MonoBehaviour
    {
        public GameObject prize;
        public bool pushed;

        // Use this for initialization
        void Start()
        {
            pushed = false;
        }

        // Update is called once per frame
        void Update()
        {
            if ( pushed )
            {
                GameObject p = Instantiate(prize, transform);
                p.transform.Translate(new Vector3(0, 5, 0));
                pushed = false;
            }
        }
    }
}