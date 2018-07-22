using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ar4477.A07
{
  // this script is attached to the enemy prefab
  public class EnemyController : NetworkBehaviour {

      public GameObject bulletPrefab;
      public Transform bulletSpawn;

  	// Use this for initialization
  	void Start ()
      {
          // repeat rotate and shooting bullet at specified intervals
          InvokeRepeating("Rotate", 1, 4.2f);
          InvokeRepeating("CmdFire", 1, 5);
  	}

      void Update()
      {
          Move();
      }

      void Move()
      {
          // translate enemy in z direction by a random amount
          var z = Random.Range(0, .1f);
          transform.Translate(0, 0, z);
      }
      void Rotate()
      {
          // rotate enemy by a random degree
          var x = Random.Range(0, 360);
          transform.Rotate(0, x, 0);
      }

      // same fire function as in the Player Controller script
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
  }

}
