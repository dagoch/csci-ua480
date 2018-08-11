using UnityEngine;
using UnityEngine.Networking;

namespace A07Examples
{
    public class PlayerController2 : NetworkBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public Transform cameraTransform;
        public Transform cameraContainerTransform;
        public Transform visorTransform;

        public GameObject pickupableThingPrefab;

        public float rotSpeed = 2.0f;
        public float transSpeed = 0.5f;

        public float ThresholdAngle
        {
            get
            {
                return _thresholdAngle;
            }
            set
            {
                _thresholdAngle = value;
                _thresholdMagnitude = Mathf.Sin(ThresholdAngle * Mathf.Deg2Rad);
            }
        }

        public float TiltingSpeed = 5.0f;

        public bool isWalking = false;

        public Vector3 direction;

        [Tooltip("If the tilting angle is below the threshold, player will not move")]
        [SerializeField]
        private float _thresholdAngle = 15f;

        private float _thresholdMagnitude;

        public bool standalone_osx = false;

        private void Start()
        {

        }

        public override void OnStartLocalPlayer()
        {
            GetComponent<Renderer>().material.color = Color.blue;
            cameraTransform = Camera.main.transform;
            cameraContainerTransform = cameraTransform.parent;

            visorTransform = transform.Find("Visor");
            cameraContainerTransform.position = visorTransform.position;
            Debug.Log("start local player: visor position = " + visorTransform.position + " camera posn = " + cameraContainerTransform.position);
            _thresholdMagnitude = Mathf.Sin(ThresholdAngle * Mathf.Deg2Rad);

            #if UNITY_STANDALONE_OSX
            standalone_osx = true;
#endif
        }

        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            // This code is only run on the Client that controls this Player object
            // So we can get input from the user for this player

            if (standalone_osx)
            {
                // this is for testing in a standalone build on the desktop (on mac)
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");

                // only turns left or right: doesn't tilt up & down
                transform.Rotate(transform.up, moveX * rotSpeed);
                transform.Translate(0, 0, moveZ * transSpeed);
                cameraContainerTransform.eulerAngles = transform.eulerAngles;

            }
            else
            {
                isWalking = false;
                float yOffset = transform.position.y;

                Vector3 tilt = cameraTransform.up;
                tilt.y = 0;
                if (tilt.magnitude > _thresholdMagnitude)
                {
                    isWalking = true;

                    direction = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized * TiltingSpeed * Time.deltaTime;
                    Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
                    transform.Translate(rotation * direction);

                    transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
                }

                // rotate the player to match the camera's rotation (controlled by GoogleVR)
                Vector3 yrot = cameraTransform.rotation.eulerAngles;
                // only rotate around y axis
                yrot.x = 0;
                yrot.z = 0;
                transform.eulerAngles = yrot;
                //        transform.rotation = cameraTransform.rotation;
            }


            // move the camera to match the player's position
            cameraContainerTransform.position = visorTransform.position;

            // Another piece of data to share: mouse clicks or spacebar presses
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                CmdFire();
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                CmdMakeAThing();
            }
        }

        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdFire()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }

        [Command]
        void CmdMakeAThing() {
            var thing = (GameObject)Instantiate(pickupableThingPrefab,
                bulletSpawn.position,
                                                bulletSpawn.rotation);
            NetworkServer.SpawnWithClientAuthority(thing, connectionToClient);


        }


    }
}
