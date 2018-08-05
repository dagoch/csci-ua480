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

        // SyncLists are SyncVars for lists.  There are several different types.
        // They do not need a SyncVar attribute tag.
        public SyncListInt players = new SyncListInt();

        // local UI text fields to display data
        public Text LastIdText;
        public Text ScorebdText;


        public override void OnStartServer()
        {
            base.OnStartServer();

            players.Add(999);  // add dummy 0th player to score list: this is just for debugging

        }


        // Update is called once per frame
        // This runs on all clients
        void Update()
        {
            // Update the information display

            LastIdText.text = "Last Id: "+lastPlayerId.ToString();

            // Display scores for each player
            string board = "Scoreboard\n";
            for (int i = 0; i < players.Count; i++)
                board += i.ToString() + ": " + players[i].ToString() +"\n";
            
            ScorebdText.text = board;
        }

        // Increment the global count of button clicks, and also the score for the given player
        // this is called from a Command by the player, so it runs as server
        public void PressButton(int playerId) {
            buttonCount++;
            Debug.Log("Button pressed, count = " + buttonCount);
            // increment count for the given player
            players[playerId]++;
        }

        // this increments lastPlayerId and adds an entry in the scoreboard array
        // this is called from a Command by the player, so it runs as server
        public void AddNewPlayer() {
            lastPlayerId++;
            players.Add(0);
            Debug.Log("Added new player: " + lastPlayerId + " now players len = " + players.Count);
        }
    }
}
