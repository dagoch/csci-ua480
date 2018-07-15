using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04_ank352
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;

		private void Awake()
		{
            //Singleton
            if (Instance == null) {
                Instance = this;
            } else if (Instance != this) {
                Destroy(this);
            }
		}

        public void Translate(Vector3 translation) {
            transform.Translate(translation, Space.World);
        }

        public void MoveToPosition(Vector3 des, float time)
        {
            StopAllCoroutines();
            des.y = transform.position.y;

            //If the distance of the travel point is greater than 10, move gradually
            if (Mathf.Abs(des.z - transform.position.z) > 10 || Mathf.Abs(des.x - transform.position.x) > 10)
              time = 5;
            //Otherwise, teleport
            else
              time = 0;
            StartCoroutine(MoveToPositionGradually(des, time));
        }

        private IEnumerator MoveToPositionGradually(Vector3 des, float time) {
          float t = 0.0f;
          Vector3 initialPos = transform.position;
          while (t < time) {
              t += Time.smoothDeltaTime;
              transform.position = initialPos + (des - initialPos) * Mathf.Lerp(0.0f, 1.0f, t / time);
              yield return null;
          }
          transform.position = des;
        }
    }
}
