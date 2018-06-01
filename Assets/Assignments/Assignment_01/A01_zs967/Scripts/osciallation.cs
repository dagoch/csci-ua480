using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A01zs967
{
    public class osciallation : MonoBehaviour
    {

        float timecounter = 0;
        float speed;
        float width;
        float height;

        // Use this for initialization
        void Start()
        {
            speed = 12;
            width = 7;
            height = 10;
        }

        // Update is called once per frame
        void Update()
        {
            timecounter += Time.deltaTime * speed;
            float x = Mathf.Cos(timecounter) * width;
            float y = Mathf.Cos(timecounter) * height;
            float z = 10;

            transform.position = new Vector3(x, y, z);

        }
    }
}