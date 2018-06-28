using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A04
{
    public class MoveToReticle : MonoBehaviour
    {

        public float speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
            }
        }
    }
}
