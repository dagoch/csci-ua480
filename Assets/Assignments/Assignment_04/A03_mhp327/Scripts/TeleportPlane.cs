using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace mhp327_A04
{
    [RequireComponent(typeof(Collider))]
    public class TeleportPlane : MonoBehaviour, IPointerClickHandler
    {
        private Collider _collider;
        public float m_DistanceZ;
        Plane m_Plane;
        Vector3 m_DistanceFromCamera;
        public float RequiredMovingTime;

        // Use this for initialization
        void Start()
        {

            _collider = GetComponent<Collider>();

            //This is how far away from the Camera the plane is placed
            m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - m_DistanceZ);
            //Create a new plane with normal (0,1,0) at the position away from the camera you define in the Inspector. This is the plane that you can click so make sure it is reachable.
            m_Plane = new Plane(Vector3.up, Vector3.zero);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
           // PlayerController.Instance.MoveToPosition(transform.position, RequiredMovingTime);

            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Initialise the enter variable
            float enter = 0.0f;

            if (m_Plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);
                //Move your cube GameObject to the point where you clicked
                // hitPoint.y = 1.5f;
                transform.position = hitPoint;
        //        PlayerController.Instance.MoveToPosition(hitPoint, RequiredMovingTime);
            }
        }

        // Update is called once per frame
//        void Update()
  //      {

    //    }
    }
}