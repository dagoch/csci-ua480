using UnityEngine;
using UnityEngine.Networking;

namespace ar4477.A07
{
  // this script is attached to the player prefab and was modeled after
  // the Unity tutorial
  public class PlayerController : NetworkBehaviour
  {
      public GameObject bulletPrefab;
      public Transform bulletSpawn;
      // set player speed
      public float speed = 2.0f;

      void Update()
      {
          // check if local player
          if (!isLocalPlayer)
          {
              return;
          }

          // adjust the camera position so that it takes the position of the player
          Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
          // adjust the euler angles of the player to those of the camera
          transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
          // move the player forward
          transform.position += transform.forward * speed * Time.deltaTime;

          // if the user hits the button, fire
          if (Input.GetMouseButtonDown(0))
          {
              CmdFire();
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

      public override void OnStartLocalPlayer()
      {
          // make local player blue
          GetComponent<Renderer>().material.color = Color.blue;
      }
  }

}
