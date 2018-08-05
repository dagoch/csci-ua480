using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace A07Examples
{
    public class GameManager : NetworkBehaviour
    {

        [SyncVar]
        public int lastPlayerId = 0;

        [SyncVar]
        public int buttonCount = 0;

        public Text LastIdText;
        public Text ScorebdText;

        public SyncListInt players = new SyncListInt();


        // Use this for initialization
        void Start()
        {
        }


        public override void OnStartServer()
        {
            base.OnStartServer();

            players.Add(999);  // add dummy 0th player to score list: this is just for debugging

        }


        // Update is called once per frame
        // This runs on all clients
        void Update()
        {
            LastIdText.text = "Last Id: "+lastPlayerId.ToString();

            // Display scores for each player
            string board = "Scoreboard\n";
            for (int i = 0; i < players.Count; i++)
                board += i.ToString() + ": " + players[i].ToString() +"\n";
            
            ScorebdText.text = board;
        }

        public void PressButton(int playerId) {
            buttonCount++;
            Debug.Log("Button pressed, count = " + buttonCount);
            players[playerId]++;

        }

        // this increments lastPlayerId and adds an entry in the scoreboard array
        public void AddNewPlayer() {
            lastPlayerId++;
            players.Add(0);
            Debug.Log("Added new player: " + lastPlayerId + " now players len = " + players.Count);
        }
    }
}
