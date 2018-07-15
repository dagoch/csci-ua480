using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_A04
{
    public class my_MakeAFace : MonoBehaviour
    {

        public GameObject[] hairs;
        public GameObject[] eyes;
        public GameObject[] noses;
        public GameObject[] mouths;

        GameObject hair, LEye, REye, nose, mouth;

        public Vector2 minMaxHair = Vector2.one;

        void Start()
        {
            //Makes 20 faces similar to the ones David made in class at 20 
            //random positions on the plane

            for (int i = 0; i < 20; i++)
            {
                //the random x and z coordinates of each face
                float temp1 = Random.Range(-50.0f, 50.0f);
                float temp2 = Random.Range(-50.0f, 50.0f);

                hair = Instantiate(hairs[Random.Range(0, hairs.Length)]);
                LEye = Instantiate(eyes[Random.Range(0, eyes.Length)]);
                REye = Instantiate(LEye);
                nose = Instantiate(mouths[Random.Range(0, noses.Length)]);
                mouth = Instantiate(noses[Random.Range(0, mouths.Length)]);


                hair.transform.localPosition = new Vector3(temp1, 3, temp2);

                //this float uses perlin with the face's randomly 
                //generatef coordinates as the two base float values
                float hairScale = Mathf.PerlinNoise(temp1, temp2);

                //the following generates the parts of the face and scales
                //it acordingly
                hair.transform.localScale = new Vector3(hairScale, hairScale, hairScale);
                LEye.transform.localPosition = new Vector3(temp1-.5f, 2, temp2);
                LEye.transform.localScale = new Vector3(hairScale, hairScale, hairScale);
                REye.transform.localPosition = new Vector3(temp1 +.5f, 2, temp2);
                REye.transform.localScale = new Vector3(-1f * LEye.transform.localScale.x, LEye.transform.localScale.y, 1);
                nose.transform.localPosition = new Vector3(temp1, 1.5f, temp2);
                nose.transform.localScale = new Vector3(hairScale, hairScale, hairScale);
                mouth.transform.localPosition = new Vector3(temp1, 1, temp2);
                mouth.transform.localScale = new Vector3(hairScale, hairScale, hairScale);
            }
        }

  
    }
}