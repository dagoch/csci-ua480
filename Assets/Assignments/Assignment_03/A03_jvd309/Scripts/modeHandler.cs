using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples{  
    public class modeHandler : MonoBehaviour {
        public bool isTranslating;
        public PickupMe _PickupMe;
        public RotateMe _RotateMe;

    	// Use this for initialization
    	void Start () {
            isTranslating = true;
            Debug.Log("DONE");
    	}
    	
    	// Update is called once per frame
    	void Update () {

    	}
        public void checkMode(){
            
        }
    }
}