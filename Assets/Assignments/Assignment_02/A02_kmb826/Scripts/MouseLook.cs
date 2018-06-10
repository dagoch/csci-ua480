using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script adapted from Maher Daaloul video at https://www.youtube.com/watch?v=T15ywpP778A
namespace kmb826_assignment02
{
    public class MouseLook : MonoBehaviour
    {
        private bool ready;
        private Vector3 mouse_coord;
        private GameObject empty_object;
        private VectorDirection vector_direction = new VectorDirection();

        private void Start()
        {
            empty_object = new GameObject("empty_object");
        }

        private void Update()
        {
            mouse_coord = new Vector3(Input.mousePosition.x - (Screen.width/2f), Input.mousePosition.y - (Screen.height / 2f), 0f);
            if(!ready)
            {
                StartCoroutine("GetVectorDirection");
            }
        }

        IEnumerator GetVectorDirection()
        {
            ready = true;
            empty_object.transform.forward = vector_direction.Direction(mouse_coord, 1.3f);
            transform.localEulerAngles = empty_object.transform.eulerAngles;
            ready = false;
            yield return null;
        }
    }
}
