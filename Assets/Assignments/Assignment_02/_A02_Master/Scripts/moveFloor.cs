using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFloor : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        //rb.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {

        rb.transform.localScale += new Vector3(0, 0.01f, 0);
        Vector3 startingPos = rb.transform.position;
        startingPos[1] = 0.1f;// the Z value
        transform.position = startingPos;

    }
}
