using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace A04ank352
{
    [RequireComponent(typeof(Collider))]
    public class MovingDestination : MonoBehaviour, IPointerClickHandler
    {
      //IPointerClickHandler
        [Tooltip("How long does the player need to get here")]
        private float RequiredMovingTime;
        private Collider _collider;

		private void Start()
		{
            _collider = GetComponent<Collider>();
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
          RaycastHit hit;
          Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
          //If ray makes contact with ground, use the hit.point
          if (Physics.Raycast(ray, out hit))
            if (Mathf.Abs(hit.point.z - Camera.main.transform.parent.position.z) < 10 && Mathf.Abs(hit.point.x - Camera.main.transform.parent.position.x) < 10)
              A04_ank352.PlayerController.Instance.MoveToPosition(hit.point, RequiredMovingTime);
        }

		private void OnTriggerEnter(Collider other)
		{
            //Disable the collision detection on this collider when the camera is inside of it, so the casting ray won't be blocked by it.
            if (other.CompareTag("MainCamera")) {
                _collider.isTrigger = true;
            }
		}

		private void OnTriggerExit(Collider other)
		{
            //Re-enable the collision detection when camera exits the collider
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = false;
            }
		}
	}
}
