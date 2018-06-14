using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A01
{
    public class SineMotion : MonoBehaviour
    {
        Vector3 startPosition;
        void Start()
        {
            startPosition = transform.position;

        }

        void Update()
        {
            float x = startPosition.x;
            float y = 5 * Mathf.Sin(Time.timeSinceLevelLoad)+startPosition.y;
            float z = startPosition.z ;
            transform.position = new Vector3 (x, y, z);
        }
    }
}
