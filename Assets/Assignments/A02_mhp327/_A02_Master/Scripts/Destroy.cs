using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used this unity tutorial for help! https://unity3d.com/learn/tutorials/topics/scripting/instantiate
namespace mhp327_Assignment02
{
    public class Destroy : MonoBehaviour
    {


        void Start()
        {
            //destroys the game object 10 seconds after instantiation
            Destroy(gameObject, 10f);
        }


    }
}