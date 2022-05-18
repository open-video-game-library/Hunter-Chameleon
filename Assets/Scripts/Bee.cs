using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace Chameleon
{
    public class Bee : Target
    {
        public float speed;
        private Vector3 direction;
        private Button loadButton;
        private Rigidbody2D rBody;
        private Transform beeTransform;
        public Sprite bee;
        private Tongue tongue;
        
        private Sprite beesprite;
        private string beepath;
        private string[] type = {
        "toLeft", "toRight"
        };
        private string flyType;

        bool isChangedDir = false;
        TargetManager targetmanager;
        void Start()
        {
            //GetComponent<SpriteRenderer>().sprite = bee;
            Destroy(gameObject, 8);
            rBody = this.GetComponent<Rigidbody2D>();
            beeTransform = this.GetComponent<Transform>();
            if (ParamBeeSize.getParam() == 0) beeTransform.localScale =  Vector3.one;
            else beeTransform.localScale = ParamBeeSize.getParam() *  Vector3.one;
            if (ParamBeeSpeed.getParam() == 0) speed = 0.05f;
            else speed = ParamBeeSpeed.getParam() * 0.2f;
            targetmanager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
            if(SceneManager.GetActiveScene().name == "EditScene")
            {
                loadButton = GameObject.Find("LoadButton").GetComponent<Button>();
                loadButton.onClick.AddListener(LoadSettings);
            }
            else if(SceneManager.GetActiveScene().name == "MainScene")
            {
                beepath = SetImage.getBeeSpritepath();
                StartCoroutine(getBeeLocalFile(beepath));
            }
            tongue = GameObject.Find("Tongue").GetComponent<Tongue>();
            
            //base.setImage = GameObject.Find("EditorManager").GetComponent<SetImage>();
            
            if(GetComponent<SpriteRenderer>().sprite == null)
            {
                GetComponent<SpriteRenderer>().sprite = bee;
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
            transform.localPosition += direction * speed;
            if (flyType == "toLeft")
            {
                if (transform.localPosition.x < 0 && !isChangedDir)
                {
                    isChangedDir = true;
                    direction.y = -direction.y;
                }
            }
            else if (flyType == "toRight")
            {
                if (transform.localPosition.x > 0 && !isChangedDir)
                {
                    isChangedDir = true;
                    direction.y = -direction.y;
                }
            }
        }

        public void Init()
        {
            var pos = Vector3.zero;
            flyType = type[Random.Range(0, type.Length)];
            switch (flyType)
            {
                case "toLeft":
                    pos.x = Random.Range(0.1f, base.respawnPosInside.x);
                    pos.y = 5.6f;
                    pos.z = 2.0f;
                    // Mathf.Sqrt
                    // direction = new Vector2(-1, -(pos.y + 2.5f) / pos.x);
                    direction = new Vector2(-pos.x / (pos.y + 2.5f), -1);
                    break;
                case "toRight":
                    pos.x = -Random.Range(0.1f, base.respawnPosInside.x);
                    pos.y = 5.6f;
                    pos.z = 2.0f;
                    // direction = new Vector2(1, (pos.y + 2.5f) / pos.x);
                    direction = new Vector2(-pos.x / (pos.y + 2.5f), -1);
                    StartCoroutine("DirectionChange");
                    break;
            }
            transform.localPosition = pos;
        }

        IEnumerator DirectionChange()
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 scale = transform.localScale;
            scale.x = -scale.x;
            transform.localScale = scale;
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

        IEnumerator getBeeLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
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
                beesprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                GetComponent<SpriteRenderer>().sprite = beesprite;
                
                for(int i=0;i<6;i++)
                {
                    if(GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        this.gameObject.AddComponent<PolygonCollider2D>();
                    }
                }
                    //DestroyImmediate(goBeeRawImage.GetComponent<PolygonCollider2D>(),true);
                    
                
            
                
                //goRawImage.GetComponent<Rigidbody2D>().sharedMaterial = physicmaterial2D;
                // goRawImage.GetComponent<BoxCollider2D>() = physicmaterial2D;
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
