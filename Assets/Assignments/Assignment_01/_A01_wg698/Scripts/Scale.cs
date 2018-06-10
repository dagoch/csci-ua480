using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wg698.A01
{

    public class Scale : MonoBehaviour
    {
        

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()

        {
            
            if (transform.localScale.x < 2.5)
            {
                transform.localScale += new Vector3(0.1f*Time.deltaTime, 0.1f* Time.deltaTime, 0.1f* Time.deltaTime);
            } 
        }
    }
}
