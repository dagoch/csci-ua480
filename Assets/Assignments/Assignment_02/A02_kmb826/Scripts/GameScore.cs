using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace kmb826_assignment02
{
    // This class with handle the score of the "game"
    public class GameScore : MonoBehaviour
    {

        static int game_score; // static variable to store score
        private TextMesh text_mesh; // text_mesh to write score to

        private void Start()
        {
            text_mesh = GetComponent<TextMesh>();
        }

        // Static method to add to score that can be called across all scripts
        public static void AddScore(int points)
        {
            game_score += points;
            Debug.Log("Score: " + game_score);
        }

        //Update the text mesh
        void Update()
        {
            text_mesh.text = "score: " + game_score.ToString();
        }
    }
}
