using UnityEngine;

namespace pk1329A04
{
    public class LookAtPlayer : MonoBehaviour
    {
        void Update()
        {
            
            Vector3 targetVector = this.transform.position - Camera.main.transform.position;

            // Rotate the BameObject to always look at the Player
            transform.rotation = Quaternion.LookRotation(targetVector, Camera.main.transform.rotation * Vector3.up);
        }
    }
}