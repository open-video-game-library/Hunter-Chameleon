using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon
{
    public class TongueCollider : MonoBehaviour
    {
        private Tongue tongue;

        public JudgmentText judgTxtPrefab;

        ScoreText scoreText;
        DataManager dataManager;
        private TimeKeeper timeKeeper;

        public int hitCount;

        [SerializeField]
        private AudioSource[] ses;

        void Start()
        {
            hitCount = 0;
            tongue = GameObject.Find("Tongue").GetComponent<Tongue>();
            // judgTxtPrefab = GameObject.Find("JudgmentText").GetComponent<JudgmentText>();
            scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
            timeKeeper = GameObject.Find("Panel").GetComponent<TimeKeeper>();
        }

        void Update()
        {
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Vector3 hitPos = collision.ClosestPoint(this.transform.position);
            float hitDis = Vector3.Distance(tongue.triggeredPos, hitPos);
            hitPos.y = hitPos.y + 20.0f;
            hitPos.z = 11.0f;
            int score = 0;
            if (collision.name.Contains("Fly"))
            {
                ses[0].Play();
                hitCount++;
                // Debug.Log(collision.name + ": " + hitPos + ", " + hitDis);
                Destroy(collision.gameObject);
                //Instantiate(judgTxtPrefab).Init(hitDis, hitPos);

                if (hitDis <= 2.0f) score = 300;
                else if (hitDis >= 2.0f && hitDis < 4.0f) score = 200;
                else if (hitDis >= 4.0f) score = 100;
            }
            if (collision.name.Contains("Apple") || collision.name.Contains("Bee"))
            {
                ses[1].Play();
                hitCount++;
                score = 50;
            }
            scoreText.AddScore(score);
            // Debug.Log(timeKeeper.playTime + ", " + hitPos.x + ", " + hitPos.y + ", " + collision.name + ", " + score);
            // string hitPos2 = "(" + (hitPos.x).ToString() + ", " + (hitPos.y).ToString() + ")";
            // dataManager.addData(timeKeeper.timer, hitPos2, collision.name, score);
            // #if UNITY_WEBGL && !UNITY_EDITOR
            //         dataManager.WriteData(timeKeeper.playTime, hitPos.x, hitPos.y, collision.name, score);
            // #endif
        }
    }
}