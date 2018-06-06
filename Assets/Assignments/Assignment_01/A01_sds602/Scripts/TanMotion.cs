using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sds602.A01
{
    public class TanMotion : MonoBehaviour
    {
        Vector3 startPosition;
        void Start()
        {
            startPosition = transform.position;

        }

        void Update()
        {
            float x = 5 * Mathf.Tan(Time.timeSinceLevelLoad) + startPosition.x;
            float y = startPosition.y;
            float z = startPosition.z;
            transform.position = new Vector3(x, y, z);
        }
    }
}
