using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corkscrew : MonoBehaviour {

    public float speed;
    public float curlSize;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Sin(Time.time) * speed, Mathf.Sin(Time.time*curlSize) * speed, Mathf.Cos(Time.time*curlSize) * speed);

    }
}
