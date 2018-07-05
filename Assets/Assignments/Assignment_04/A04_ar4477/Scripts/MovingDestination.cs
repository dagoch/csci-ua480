using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// this script is attached to the plane
namespace ar4477.A04
{
    [RequireComponent(typeof(Collider))]
    public class MovingDestination : MonoBehaviour, IPointerClickHandler
    {
        [Tooltip("How long does the player need to get here")]
        public float RequiredMovingTime;


        // the spot where the user will teleport to
        RaycastHit pos;

		private void Start()
		{
           
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            // if Raycast intersects the plane within 10 meters of user, move the user
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out pos, 10))
            {
                // Move player to position of the Raycast Hit in the required moving time, which
                // should be set to 0 in inspector.
                // A time of 0 makes the move instant
                PlayerController.Instance.MoveToPosition(pos.point, RequiredMovingTime);
            }
        }
	}
}
