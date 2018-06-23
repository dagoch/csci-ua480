using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_cc5341
{

    [RequireComponent(typeof(Canvas))]
    public class move_or_rotate : MonoBehaviour
    {


        public static move_or_rotate Instance;

        [HideInInspector]
        public GameObject ball;

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
            Vector3 dis = Camera.main.transform.position - transform.position;
            _distanceToCamera = Vector3.Project(dis, Camera.main.transform.forward).magnitude;
        }

        bool rotating = false;
        private void Update()
        {
            
            if(rotating){
                print(Camera.main.transform.eulerAngles.x);
                ballRB.transform.Rotate(new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z));
            }
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
            }
            else
            {
                ball = sender;
                ballRB = ball.GetComponent<Rigidbody>();
                transform.position = Camera.main.transform.position + Camera.main.transform.forward * _distanceToCamera;
                transform.forward = Camera.main.transform.forward;
                SetChildrenActive(true);
                _isShowing = true;
            }
        }

        public void Hide()
        {
            ball = null;
            SetChildrenActive(false);
            _isShowing = false;
        }

        Rigidbody ballRB;
        public void select_move()
        {
            print("move");


            ballRB.isKinematic = true;
            ballRB.transform.parent = Camera.main.transform;
            Hide();
        }

        public void select_rotate()
        {
            print("rotate by camera");


            rotating = true;

            Hide();
        }
    }
}