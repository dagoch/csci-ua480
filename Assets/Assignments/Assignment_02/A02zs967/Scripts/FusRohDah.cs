using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusRohDah : MonoBehaviour
{

    public AudioClip frd;
    public Camera Camera;
    public GameObject cube;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        bool down = Input.GetKey(KeyCode.F);
        if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;
            if (down)
            {
                cube.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * 5000);
                if (frd != null){
                    AudioSource.PlayClipAtPoint(frd, Camera.main.transform.position);
                }
            }
        }
    }
}
