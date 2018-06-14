using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class PressButton : MonoBehaviour
    {

        public float maxActivationDistance;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if ( Input.GetKeyDown(KeyCode.E) )
            {
                RaycastHit hit;
                Ray ptr = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ptr, out hit))
                {
                    if ( (hit.transform.position - transform.position).magnitude <= maxActivationDistance)
                    {
                        Debug.Log("hit a something within distance!");
                        Button bttnScript = hit.collider.gameObject.GetComponent<Button>();
                        if (bttnScript != null)
                        {
                            bttnScript.pushed = true;
                        }
                    }
                }

            }
        }
    }
}