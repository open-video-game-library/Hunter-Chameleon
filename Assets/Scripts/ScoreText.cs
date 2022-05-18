using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chameleon
{
    public class ScoreText : MonoBehaviour
    {
        public int score;
        public Text scoreText;
        private TargetManager targetManager;
        void Start()
        {
            score = 0;
            targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
        }

        public void AddScore(int addedscore)
        {
            score += addedscore;
        }

        void FixedUpdate()
        {
            if(targetManager.Playnow)
            scoreText.text = "SCORE: " + score.ToString();
        }
    }
}

