using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �R���d�v

namespace Chameleon
{
    public class StageManager : MonoBehaviour
    {
        private GameObject[] deafaultStageComponents = new GameObject[4];
        public bool defaultstage=true;
        // Start is called before the first frame update
        void Start()
        {
            deafaultStageComponents[0]=GameObject.Find("Background Far");
            deafaultStageComponents[1] = GameObject.Find("Background Middle");
            deafaultStageComponents[2] = GameObject.Find("Background Close");
            deafaultStageComponents[3] = GameObject.Find("Foreground");

            defaultstage = SetImage.getHitPoint();
            if (!defaultstage) UnactiveDeafaultStage();
        }

        // Update is called once per frame
        void Update()
        {
            if (SceneManager.GetActiveScene().name == "MenuScene"||SceneManager.GetActiveScene().name == "EditScene")
            {
                defaultstage = SetImage.getHitPoint();
                if (!defaultstage) UnactiveDeafaultStage();
            }
        }

        private void UnactiveDeafaultStage()
        {
            for (int i=0;i<4;i++)
            {
                deafaultStageComponents[i].SetActive(false);
            }
        }
    }

}
