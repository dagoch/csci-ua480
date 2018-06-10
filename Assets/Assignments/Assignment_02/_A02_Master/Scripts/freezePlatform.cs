using UnityEngine;
using System.Collections;

public class freezePlatform : MonoBehaviour
{
    private Quaternion q;
    private Vector3 v3;
    private bool hasHit = false;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
       
    }

    void OnCollisionEnter(Collision col)
    {
        rb.isKinematic = true;
        hasHit = true;
    }

    void LateUpdate()
    {
        if (hasHit)
        {
            transform.position = v3;
            transform.rotation = q;
            hasHit = false;
        }
        else
        {
            v3 = transform.position;
            q = transform.rotation;
        }
    }
}