using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chameleon
{
    public class FinalScoreText : MonoBehaviour
    {
        ScoreText scoreText;

        public GameObject finalScore;
        Text finalScoreText;

        void Start()
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
            finalScoreText = finalScore.GetComponent<Text>();
            finalScore.SetActive(false);
        }

        void Update()
        {
            finalScoreText.text = "SCORE: " + scoreText.score.ToString();
        }
    }
}