using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A02_zs967{
    public class Shooting : MonoBehaviour
    {

        GameObject prefab;
        Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            prefab = Resources.Load("bullet") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0)){
                GameObject bullet = Instantiate(prefab) as GameObject;
                bullet.transform.position = transform.position + Camera.main.transform.forward * 2;
                rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 40;

            }
        }
    }
}