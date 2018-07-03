﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lga238
{
    [RequireComponent(typeof(Canvas))]
    public class MenuCanvasController : MonoBehaviour
    {
        public static MenuCanvasController Instance;

        [HideInInspector]
        public GameObject ControllingObject;
        public GameObject Cube;

        private Canvas _canvas;
        private float _distanceToCamera;
        private bool _isShowing;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            Hide();

           Cube = GameObject.Find("ControlCube");

            //Get the initial distance between the canvas and the camera, and project it on the camera's forward direction
            Vector3 dis = Camera.main.transform.position - transform.position;
            _distanceToCamera = Vector3.Project(dis, Camera.main.transform.forward).magnitude;
            Debug.Log(Cube.transform);
        }

        private void SetChildrenActive(bool isActive)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(isActive);
            }
        }

        public void Show(GameObject sender)
        {
            if (_isShowing)
            {
                Hide();
                Cube.transform.parent = Camera.main.transform;
            }
            else{
                ControllingObject = sender;
                transform.position = new Vector3(-1,10,-14);//Camera.main.transform.position + Camera.main.transform.forward * (_distanceToCamera -3);
                transform.forward = Camera.main.transform.forward;
                SetChildrenActive(true);
                _isShowing = true;
                Cube.transform.parent = null;
            }
        }

        public void Hide()
        {
            ControllingObject = null;
            SetChildrenActive(false);
            _isShowing = false;
        }
    }
}
