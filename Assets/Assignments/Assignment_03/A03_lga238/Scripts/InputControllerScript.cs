using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lga238 {
[System.Serializable]
	public enum InputMode{
		Scale, Rotate, Translate
	}

public class InputControllerScript : MonoBehaviour {
	public static InputControllerScript Instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
	public InputMode cubeMode = new InputMode();
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		
	}

	public void setInputMode(int x){
		cubeMode = (InputMode)x;
	}
}
}
