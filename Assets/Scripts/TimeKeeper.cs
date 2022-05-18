using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chameleon
{
    public class TimeKeeper : MonoBehaviour
    {
        // public Text time_text;
        public float playTime;
        public float timer;
        Image fadeImage;
        float fadeSpeed, red, green, blue, alfa;

        [System.NonSerialized]
        public int skyNum;

        public GameObject tongue;
        TongueCollider tongueCollider;
        public GameObject finishText;
        public GameObject toMenuBtn;
        public GameObject retryBtn;
        GameObject downloadButton;
        public GameObject cursorAim;

        DataManager dataManager;
        ScoreText scoreText;
        public GameObject finalScoreText;
        private GraphicRaycaster inGameCanvasGraphicRaycaster;
        BGMManager bgmManager;

        public bool isFinised = false;
        private TargetManager targetManager;
        public GameObject dummyCursorAim;

        [SerializeField]
        private AudioSource finishSound;

        void Start()
        {
            // time_text = GameObject.Find("Time").GetComponent<Text>();
            fadeImage = GetComponent<Image>();
            red = fadeImage.color.r;
            green = fadeImage.color.g;
            blue = fadeImage.color.b;
            alfa = fadeImage.color.a;
            alfa = 0.4f;
            fadeSpeed = (alfa * 0.02f) / (playTime / 2.0f);
            skyNum = 0;
            inGameCanvasGraphicRaycaster = GameObject.Find("InGameCanvas").GetComponent<GraphicRaycaster>();
            inGameCanvasGraphicRaycaster.enabled = false;
            tongue = GameObject.Find("Tongue");
            toMenuBtn = GameObject.Find("InGameCanvas/ToMenuButton");
            retryBtn = GameObject.Find("InGameCanvas/RetryButton");
            downloadButton = GameObject.Find("InGameCanvas/DownloadButton");
            cursorAim = GameObject.Find("CursorAim");
            finishText.SetActive(false);
            toMenuBtn.SetActive(false);
            retryBtn.SetActive(false);
            downloadButton.SetActive(false);
            dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
            scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
            tongueCollider = GameObject.Find("TongueCollider").GetComponent<TongueCollider>();
            targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
            bgmManager = GameObject.Find("BGM").GetComponent<BGMManager>();

            if (ParamTime.getParam() == 0) playTime = 30;
            else playTime = ParamTime.getParam();
        }

        // Update is called once per frame!
        void Update()
        {
            // time_text.text = timer.ToString();
            timer += Time.deltaTime;
            if (timer < (playTime / 3))
            {
                //morning
                skyNum = 0;
            }
            else if (timer < ((playTime / 3) * 2))
            {
                //day
                skyNum = 1;
            }
            else if (timer < playTime)
            {
                //sunset
                skyNum = 2;
            }
            else
            {
                //night(finish)
                skyNum = 3;
            }
            // Debug.Log(skyNum);

            if (timer < (playTime / 2))
            {
                alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
                SetAlpha();
            }
            else
            {
                alfa += fadeSpeed;                //a)不透明度を徐々に下げる
                SetAlpha();
            }

            if (timer >= playTime)
            {
                Finish();
            }
        }

        void SetAlpha()
        {
            if (alfa <= 0 || alfa > 0.4)
            {
                return;
            }
            // Debug.Log("timer: " + timer + ", alfa: " + alfa);
            fadeImage.color = new Color(red, green, blue, alfa);
        }

        public void Finish()
        {
            if (!isFinised)
            {
                targetManager.Playnow = false;
                inGameCanvasGraphicRaycaster.enabled = true;
                Cursor.visible = true;
                finishSound.Play();
                bgmManager.PlayEd();
                Tongue _tongue = tongue.GetComponent<Tongue>();
                isFinised = true;
                Invoke("showEndScreen", 2f);
                finishText.SetActive(true);
                dataManager.postData(scoreText.score, tongueCollider.hitCount, _tongue.triggerCount, (int)timer);
                //tongue.SetActive(false);
                cursorAim.SetActive(false);
                GameObject.Find("ScoreText").SetActive(false);
            }
        }

        private void showEndScreen(){
            finishText.SetActive(false);
            finalScoreText.SetActive(true);
            toMenuBtn.SetActive(true);
            retryBtn.SetActive(true);
            downloadButton.SetActive(true);
            dummyCursorAim.SetActive(true);
        }
    }
}
