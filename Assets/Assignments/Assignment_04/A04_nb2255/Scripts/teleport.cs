using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    public ParticleSystem effect;
    public float maxActivationDistance = 10f;
    private ParticleSystem party;
    bool playing = false;

	// Use this for initialization
	void Start () {
        party = Instantiate(effect, this.transform);
        party.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ptr = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        //make a raycast
        if (Physics.Raycast(ptr, out hit))
        {
            //if it hits something within the distance
            if (hit.distance <= maxActivationDistance)
            {
                //Debug.Log("hit a something within distance!");
                //move the particle emmitter to the place where it hit
                party.transform.position = hit.point;
                //if our particle emmitter is currently stopped
                if (!playing)
                {
                    //play it, and take note that we did so
                    playing = true;
                    party.Play();
                }
                //if the user pressed the teleport button in this frame
                if ( Input.GetMouseButtonDown(0) )
                {
                    //teleport them to the position of the hit
                    transform.position = hit.point + Vector3.up * 1.3f;
                }
            }
            else
            {
                //if we hit something but we're not in range
                if (playing)
                {
                    //stop playing
                    playing = false;
                    party.Stop();
                }
            }
        }
        else
        {
            //if we don't hit anything at all
            if (playing)
            {
                //and we were playing the particle emmitter
                //then stop it
                playing = false;
                party.Stop();
            }
        }
    }
}
