using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is based off the code implemented in class.

namespace A04_jvw2421
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Object;

        private void On()
        {
            //Singleton
            if (Object == null)
            {
                Object = this;
            }
            else if (Object != this)
            {
                Destroy(this);
            }
        }

        public void Translate(Vector3 translation)
        {
            transform.Translate(translation, Space.World);
        }

        public void MoveToPosition(Vector3 des, float time)
        {
            StopAllCoroutines();
            des.y = transform.position.y;
            StartCoroutine(MoveToPositionGradually(des, time));
        }

        private IEnumerator MoveToPositionGradually(Vector3 des, float time)
        {
            float t = 0.0f;
            Vector3 initialPos = transform.position;
            while (t < time)
            {
                t += Time.smoothDeltaTime;
                transform.position = initialPos + (des - initialPos) * Mathf.Lerp(0.0f, 1.0f, t / time);
                yield return null;
            }
            transform.position = des;
        }
    }
}
