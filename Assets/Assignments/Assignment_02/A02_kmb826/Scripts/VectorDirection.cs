using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script adapted from Maher Daaloul video at https://www.youtube.com/watch?v=T15ywpP778A
namespace kmb826_assignment02
{
    public class VectorDirection
    {

        public Vector3 Direction(Vector3 mouse_screen, float angle_lim)
        {
            float max_X = 50f * Mathf.Tan(angle_lim);
            float max_Y = max_X;

            float mouse_x = (mouse_screen.x * max_X) / (Screen.width / 2f); // find mouse x-value
            float mouse_y = (mouse_screen.y * max_Y) / (Screen.height / 2f); // find mouse y-value
            Vector3 v = new Vector3(mouse_x, mouse_y, 50f);

            return v; // return Vector3 value to use for mouse coordinates on screen
        }
    }
}
