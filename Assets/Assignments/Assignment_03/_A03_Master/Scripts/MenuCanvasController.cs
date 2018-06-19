using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MenuCanvasController : MonoBehaviour {
    private Canvas _canvas;
    private float _distanceToCamera;

	private void Start()
	{
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;

        //Get the initial distance between the canvas and the camera, and project it on the camera's forward direction
        Vector3 dis = Camera.main.transform.position - transform.position;
        _distanceToCamera = Vector3.Project(dis, Camera.main.transform.forward).magnitude;
	}

	public void Show () {
        _canvas.enabled = true;
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * _distanceToCamera;
        transform.forward = Camera.main.transform.forward;
    }

    public void Hide() {
        _canvas.enabled = false;
    }
}
