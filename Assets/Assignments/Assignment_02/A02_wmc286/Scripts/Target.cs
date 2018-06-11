using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class Target : MonoBehaviour
    {
        private static readonly int[] targetXBoundaries = new int[2] { 9, -9 };
        private static readonly int[] targetYBoundaries = new int[2] { 9, 1 };

        private const int targetXRotate = 200;
        private const int targetYRotate = 110;
        private const int targetZRotate = 309;

        private const float targetMoveSpeed = 0.1f;
        private bool targetXPosAddFlag = true;
        private bool targetYPosAddFlag = false;
        private int hitCount = 0;


        void Update()
        {
            transform.Rotate(new Vector3(targetXRotate, targetYRotate, targetZRotate) * Time.deltaTime);
            MoveTarget();
        }

        private void MoveTarget()
        {
            if (targetXPosAddFlag)
                transform.position = new Vector3(transform.position.x + targetMoveSpeed, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - targetMoveSpeed, transform.position.y, transform.position.z);

            if (targetYPosAddFlag)
                transform.position = new Vector3(transform.position.x, transform.position.y + targetMoveSpeed, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y - targetMoveSpeed, transform.position.z);

            CheckTargetBoundary(transform.position.x, transform.position.y);
        }

        private void CheckTargetBoundary(float currentX, float currentY)
        {
            if (currentX >= Target.targetXBoundaries[0])
                targetXPosAddFlag = false;
            else
                targetXPosAddFlag |= currentX <= Target.targetXBoundaries[1];

            if (currentY >= Target.targetYBoundaries[0])
                targetYPosAddFlag = false;
            else
                targetYPosAddFlag |= currentY <= Target.targetYBoundaries[1];
        }

        private void OnTriggerEnter(Collider other)
        {
            hitCount++;
            switch (hitCount)
            {
                case 1:
                    this.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 2:
                    this.GetComponent<Renderer>().material.color = Color.magenta;
                    break;
                case 3:
                    this.GetComponent<Renderer>().material.color = Color.red;
                    break;
                default:
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}