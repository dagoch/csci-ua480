using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class Player : MonoBehaviour
    {

        private int playerMoveSpeed = 10;
        private const int playerYPos = 2;
        private const int playerZPos = -9;
        private int posDifference = 2;
        private int rotationLimit = 45;

        public GameObject currentProjectile;
        public GameObject inAmmoBoxProjectile;
        public GameObject swapAmmoText;
        private UnityEngine.KeyCode trigger = KeyCode.Space;
        private int projectileSpeed = 1000;
        private string changeToProjectileText = "Sphere";
        private string defaultChangeToProjectileMessage = "Press C to use:";
        private bool projectileIndex = true;

        void Update()
        {
            CheckPlayerBoundary();
            Move();
            EnforcePlayerRotationLimits();
            DisplayChangeProjectileMenu();

            // Modification of an existing Fire() method found on the Unity forums
            if (Input.GetKeyDown(trigger) || Input.GetMouseButtonDown(0))
                Fire();
        }

        // ---------- Player Movement
        private void Move()
        {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(new Vector3(-playerMoveSpeed * Time.deltaTime, 0, 0));

            if (Input.GetKey(KeyCode.D))
                transform.Translate(new Vector3(playerMoveSpeed * Time.deltaTime, 0, 0));

            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }

        private void CheckPlayerBoundary()
        {
            float epsilon = 1.0f;
            float playerPos = transform.position.x;
            float westBoundaryPos = GameObject.Find("WestBoundary").transform.position.x;
            float eastBoundaryPos = GameObject.Find("EastBoundary").transform.position.x;

            if (-westBoundaryPos + playerPos < epsilon)
                transform.position = new Vector3(eastBoundaryPos - posDifference, playerYPos, playerZPos);

            if (eastBoundaryPos - playerPos < epsilon)
                transform.position = new Vector3(westBoundaryPos + posDifference, playerYPos, playerZPos);
        }

        private void EnforcePlayerRotationLimits()
        {
            float playerYRotation = transform.eulerAngles.y;
            float playerZRotation = transform.eulerAngles.z;

            if (playerYRotation < 0 || playerYRotation > 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

            if (playerZRotation < 0 || playerZRotation > 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        // ---------- Projectile
        void DisplayChangeProjectileMenu()
        {
            float playerXRotation = transform.eulerAngles.x;
            float playerXPosition = transform.position.x;
            if ((playerXRotation > 55 && playerXRotation < 75) && (playerXPosition > -1 && playerXPosition < 1))
            {
                UnityEngine.UI.Text currentSwapAmmoText = swapAmmoText.GetComponent<UnityEngine.UI.Text>();
                currentSwapAmmoText.text = "";
                currentSwapAmmoText.text = (defaultChangeToProjectileMessage + "\n" + changeToProjectileText);
                swapAmmoText.SetActive(true);
                if (Input.GetKey(KeyCode.C))
                {
                    GameObject temp = currentProjectile;
                    currentProjectile = inAmmoBoxProjectile;
                    inAmmoBoxProjectile = temp;
                    projectileIndex = !projectileIndex;
                    if (projectileIndex)
                        changeToProjectileText = "Sphere";
                    else
                        changeToProjectileText = "Capsule";
                }

            }
            else
                swapAmmoText.SetActive(false);
        }

        // Modification of an existing Fire() method found on the Unity forums
        void Fire()
        {
            GameObject projectile = currentProjectile;
            GameObject nextShot = Instantiate(projectile, new Vector3(transform.position.x, 1.5f, -8), Quaternion.Euler(90, 0, 0)) as GameObject;
            nextShot.transform.Rotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));
            nextShot.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
            Destroy(nextShot, 2.0f);
        }
    }
}