using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace rmh410.A01 {

public class MoveElectron : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Random.InitState(86);
	}

	// gaussian generator courtesy of https://stackoverflow.com/questions/5817490/implementing-box-mueller-random-number-generator-in-c-sharp
	public static float NextGaussianDouble()
	{
	    float u, v, S;

	    do
	    {
	        u = 2.0f * Random.value - 1.0f;
	        v = 2.0f * Random.value - 1.0f;
	        S = u * u + v * v;
	    }
	    while (S >= 1.0f);

	    float fac = Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
	    return u * fac;
	}
	
	// Update is called once per frame
	void Update () {
		// lets approximate the electron density function using the more easily modeled normal distribution
		float mean = 1.35f;
		float stdev = 0.45f;
		float r = NextGaussianDouble()*stdev + mean;
		// get a random direction
		float x = Random.value-0.5f;
		float y = Random.value-0.5f;
		float z = Random.value-0.5f;
		// set the magnitude to r
		float mag = Mathf.Sqrt(Mathf.Pow(x,2f)+Mathf.Pow(y,2f)+Mathf.Pow(z,2f));
		x = x/mag*r;
		y = y/mag*r;
		z = z/mag*r;
		// set our position
		transform.localPosition = new Vector3(x,y,z);
		
	}
}

}
