using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pk1329A04
{
    public class MakeAFace : MonoBehaviour
    {

        public GameObject[] hairs;
        public GameObject[] eyes;
        public GameObject[] noses;
        public GameObject[] mouths;

        GameObject hair, LEye, REye, nose, mouth;

        public Vector2 minMaxHair = Vector2.one;

        void Start()
        {
            hair = Instantiate(hairs[Random.Range(0, hairs.Length)], transform);
            LEye = Instantiate(eyes[Random.Range(0, eyes.Length)], transform);
            REye = Instantiate(LEye, transform);
            nose = Instantiate(mouths[Random.Range(0, noses.Length)], transform);
            mouth = Instantiate(noses[Random.Range(0, mouths.Length)],transform);

            hair.transform.localPosition = new Vector3(0, 2, -0.5f);
            float hairScale = Random.Range(minMaxHair.x, minMaxHair.y);
            hair.transform.localScale = new Vector3(hairScale, hairScale, hairScale);
            LEye.transform.localPosition = new Vector3(-.5f, 1, -0.5f);
            REye.transform.localPosition = new Vector3(.5f, 1, -0.5f);
            REye.transform.localScale = new Vector3(-1f * LEye.transform.localScale.x, LEye.transform.localScale.y, 1);
            nose.transform.localPosition = new Vector3(0, 0.5f, -0.5f);
            mouth.transform.localPosition = new Vector3(0, 0, -0.5f);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}