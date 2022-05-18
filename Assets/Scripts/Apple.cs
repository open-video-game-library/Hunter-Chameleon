using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace Chameleon
{
    public class Apple : Target
    {
        // public int damage;

        Vector3 localGravity;
        private Rigidbody2D rBody;
        private Transform appleTransform;
        TargetManager targetmanager;
        private Button loadButton;
        public Sprite apple;
        private Tongue tongue;
        private string applepath;
        private Sprite applesprite;
        void Start()
        {
            //GetComponent<SpriteRenderer>().sprite = apple;
            Destroy(gameObject, 6);
            rBody = this.GetComponent<Rigidbody2D>();
            appleTransform = this.GetComponent<Transform>();
            if (ParamAppleSize.getParam() == 0) appleTransform.localScale =  Vector3.one;
            else appleTransform.localScale = ParamAppleSize.getParam() *  Vector3.one;
            if (ParamAppleSpeed.getParam() == 0) rBody.gravityScale = 0.5f;
            else rBody.gravityScale = ParamAppleSpeed.getParam();
            targetmanager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
            if(SceneManager.GetActiveScene().name == "EditScene")
            {
                loadButton = GameObject.Find("LoadButton").GetComponent<Button>();
                loadButton.onClick.AddListener(LoadSettings);
            }
            else if(SceneManager.GetActiveScene().name == "MainScene")
            {
                applepath = SetImage.getAppleSpritepath();
                StartCoroutine(getAppleLocalFile(applepath));
            }
            tongue = GameObject.Find("Tongue").GetComponent<Tongue>();
            if(GetComponent<SpriteRenderer>().sprite == null)
            {
                GetComponent<SpriteRenderer>().sprite = apple;
                for(int i=0;i<6;i++)
                {
                    if(GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        gameObject.AddComponent<PolygonCollider2D>();
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, 0, 10));
        }

        public void Init()
        {
            var pos = Vector3.zero;
            pos.x = Random.Range(-base.respawnPosInside.x, base.respawnPosInside.x);
            pos.y = base.respawnPosOutside.y;
            pos.z = 2.0f;
            transform.localPosition = pos;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
        
            if (collision.name.Contains("TongueCollider"))
            {
                Destroy(gameObject);
            }
            if (collision.name.Contains("Chameleon"))
            {
                // プレイヤーにダメージを与える
                var chameleon = collision.GetComponent<Chameleon>();
                if(targetmanager.playmode) chameleon.Damage();
                Destroy(gameObject);
            }
        }

        private void LoadSettings()
        {
            if (ParamAppleSpeed.getParam() == 0) rBody.gravityScale = 0.5f;
            else rBody.gravityScale = ParamAppleSpeed.getParam();
        }

        public void onClickAct() 
        {
            tongue.Hitting(this.gameObject);
        }

        IEnumerator getAppleLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
        {
            UnityWebRequest request =
                        UnityWebRequestTexture.GetTexture("file://" + filename);
            //UnityWebRequestTexture.GetTexture("file://" + filename);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {

                //var colliderComponent = goRawImage.GetComponent<PolygonCollider2D>();
                //if(colliderComponent!=null) Destroy(colliderComponent);
                Texture tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Texture2D tex2d = ToTexture2D(tex);
                applesprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                GetComponent<SpriteRenderer>().sprite = applesprite;
                for(int i=0;i<6;i++)
                {
                    if(GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        this.gameObject.AddComponent<PolygonCollider2D>();
                    }
                }
            }


        }

        private Texture2D ToTexture2D(Texture self)
        {
            
            var sw = self.width;
            var sh = self.height;
            var format = TextureFormat.RGBA32;
            var result = new Texture2D(sw, sh, format, false);
            var currentRT = RenderTexture.active;
            var rt = new RenderTexture(sw, sh, 32);
            Graphics.Blit(self, rt);
            RenderTexture.active = rt;
            var source = new Rect(0, 0, rt.width, rt.height);
            result.ReadPixels(source, 0, 0);
            result.Apply();
            RenderTexture.active = currentRT;
            return result;
        }

        
    }

}

