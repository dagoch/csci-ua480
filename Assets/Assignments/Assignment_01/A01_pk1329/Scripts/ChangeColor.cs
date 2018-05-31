using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace pk1329A01
{
    public class ChangeColor : MonoBehaviour
    {
        public Text myText;
        public Color newColor;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            myText.color = newColor;
        }
    }
}
