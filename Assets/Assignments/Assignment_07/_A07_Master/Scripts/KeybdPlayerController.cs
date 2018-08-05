using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace A07Examples
{
    public class KeybdPlayerController : NetworkBehaviour
    {

        public float rotSpeed = 2.0f;
        public float transSpeed = 0.5f;

        [SyncVar(hook = "OnPlayerIdChange")]
        public int playerId;

        // if you have a SyncVar hook, the variable itself is not changed directly;
        // instead you get the new value in the hook function and need to set the var yourself
        void OnPlayerIdChange(int id)
        {
            playerId = id;
            Debug.Log("Player id set on player " + playerId );

            idText.text = playerId.ToString();
        }


        public Text idText;


        public GameManager gameManager;

        // Use this for initialization
        void Start()
        {

        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            Debug.Log("Get GameManager on Server");

            while (gameManager == null)
            {
                GameObject temp = GameObject.Find("Game Manager");
                if (temp != null)
                    gameManager = temp.GetComponent<GameManager>();
            }

        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            // this is a non-local player object.  it has received an id from the server;
            // need to set my text to show it.
            idText.text = playerId.ToString();

            Debug.Log("Client non-local player started with id: " + playerId);

        }


        public override void OnStartLocalPlayer()
        {
            GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Get GameManager on Player");
            while (gameManager == null)
            {
                GameObject temp = GameObject.Find("Game Manager");
                if (temp != null)
                    gameManager = temp.GetComponent<GameManager>();
            }
            // Tell server a new player has started
                CmdIncrPlayerId();
        }

        // This Increments the player count on the server
        [Command]
        void CmdIncrPlayerId() {
            Debug.Log("Incrementing lastPlayerId");
            gameManager.AddNewPlayer();   // this increments lastPlayerId and adds an entry in the scoreboard array

            // Here I am letting the server send the new value via the syncvar
            playerId = gameManager.lastPlayerId;

            // Alternately I can call an Rpc method on the client and send it the player id
//            RpcSetId(gameManager.lastPlayerId);
        }

        // this is alternate to using syncvar: can use RPC to set value on each client
        [ClientRpc]  // called on the Server, but invoked on the Clients
        void RpcSetId(int id)
        {
                Debug.Log("Player got rpcsetid = " + id);
                playerId = id;
                idText.text = playerId.ToString();

        }


        // Update is called once per frame
        void Update()
        {

//            idText.text = playerId.ToString();

            if (!isLocalPlayer) {
                return;
            }



            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            transform.Rotate(transform.up, moveX * rotSpeed);
            transform.Translate(0, 0, moveZ * transSpeed);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0)) // || Input.GetMouseButton(0)
            {
                CmdCountMe();
            }

        }

        [Command]
        void CmdCountMe() {
            gameManager.PressButton(playerId);
        }


    }
}
