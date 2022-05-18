using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Chameleon
{
    public class Tongue : MonoBehaviour
    {
        private bool isShooting;
        private bool isReached;

        private float distance;
        private float scaleY;

        public float frame;
        TimeKeeper timeKeeper;
        [System.NonSerialized]
        public Vector3 triggeredPos = Vector3.zero;

        [SerializeField]
        private AudioSource tongueSound;
        ScoreText scoreText;
        public int triggerCount;
        public int hitCount;
        //private int score = 0;
        [SerializeField]
        private AudioSource[] ses;
        

        void Start()
        {
            triggerCount = 0;
            scaleY = transform.localScale.y;
            scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>(); 
            if(SceneManager.GetActiveScene().name == "MainScene")
            timeKeeper = GameObject.Find("InGameCanvas/Panel").GetComponent<TimeKeeper>();
        }

        private void Update()
        {
            if (isShooting)
            {
                Shoot();
            }
        }

        private void LateUpdate()
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
            transform.position = new Vector3((max.x + min.x) / 2.0f, -4.6f, 1.0f);
        }

        public void Trigger(Vector3 _aimPos)
        {
            Debug.Log("trigger");
            if (!isShooting)
            {
                triggerCount++;
                tongueSound.Play();
                triggeredPos = _aimPos;
                isReached = false;
                var angle = GetAim(transform.position, _aimPos);
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                distance = Vector3.Distance(transform.position, _aimPos);
                isShooting = true;
            }
        }

    /*
        public void RayCast(Vector3 _aimPos)
        {
            if (!isShooting)
            {
                triggerCount++;
                tongueSound.Play();
                triggeredPos = _aimPos;
                isReached = false;
                var angle = GetAim(transform.position, _aimPos);
                transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                distance = Vector3.Distance(transform.position, _aimPos);
                isShooting = true;

                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray;
                ray = new Ray(_aimPos, Vector3.forward);
                RaycastHit hit;
                var target = _aimPos + ray.direction * 100;
                Debug.DrawRay(_aimPos, target, Color.red);
                Debug.Log("DAFDSF");
                if (Physics.Raycast(ray,out hit,1000.0f))
                {
                    Debug.Log(hit.collider.gameObject.transform.position);
                }
            }
        }
    */
        public void Shoot()
        {
            var speed = distance / frame;
            if (!isReached)
            {
                scaleY += speed;
                if (scaleY >= distance)
                {
                    isReached = true;
                    scaleY = distance;
                }
            }
            else
            {
                scaleY -= speed;
                if (scaleY <= 0.6f)
                {
                    isShooting = false;
                    scaleY = 0.6f;
                }
            }
            transform.localScale = new Vector3(0.6f, scaleY, 1.0f);
            Debug.Log("scale");
        }

        public float GetAim(Vector2 from, Vector2 to)
        {
            float dx = to.x - from.x;
            float dy = to.y - from.y;
            float rad = Mathf.Atan2(dy, dx);
            return rad * Mathf.Rad2Deg;
        }

        public void Test(Vector3 _aimPos)
        {
            var testAngle = GetAim(transform.position, _aimPos);
            transform.rotation = Quaternion.Euler(0, 0, testAngle - 90);
            var testDistance = Vector3.Distance(transform.position, _aimPos);
            transform.localScale = new Vector3(0.6f, testDistance, 1.0f);
        }

        public void Hitting(GameObject hitobj)
        {
            Shoot();
            Debug.Log("hitting");
            if(SceneManager.GetActiveScene().name == "MainScene")
            {
                if(!timeKeeper.isFinised)
                {
                    int score = 0;
                    ses[0].Play();
                    hitCount++;       
                    Destroy(hitobj);
                    if(hitobj.name.Contains("Fly")) score = 3000;
                    else if(hitobj.name.Contains("Apple")) score = 500;
                    else if(hitobj.name.Contains("Bee")) score = 500;
                    else Debug.Log(hitobj.name);
                    
                    scoreText.AddScore(score);
                }
            }
            else
            {
                int score = 0;
                ses[0].Play();
                hitCount++;       
                Destroy(hitobj);
                if(hitobj.name.Contains("Fly")) score = 3000;
                else if(hitobj.name.Contains("Apple")) score = 500;
                else if(hitobj.name.Contains("Bee")) score = 500;
                else Debug.Log(hitobj.name);
                
                scoreText.AddScore(score);
            }
            
            
        }
    }
}