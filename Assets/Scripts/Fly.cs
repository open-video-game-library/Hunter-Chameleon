using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


namespace Chameleon
{
    public class Fly : Target
    {
        public float speed;
        private Vector3 direction;
        private Button loadButton;
        private Rigidbody2D rBody;
        private Transform flyTransform;
        public Sprite fly;
        private Tongue tongue;
        private Sprite flysprite;
        private string flypath;
        private string[] type = {
        "toLeft", "toRight", "toLeftWave", "toRightWave", "toLeftGiza", "toRightGiza"
        };
        private string flyType;
        private string verticalDirection = "up";
        private Vector3 scale;
        void Start()
        {
            Debug.Log("Start");
            //GetComponent<SpriteRenderer>().sprite = fly;
            Destroy(gameObject, 8);
            rBody = this.GetComponent<Rigidbody2D>();
            flyTransform = this.GetComponent<Transform>();
            if (ParamFlySize.getParam() == 0) flyTransform.localScale =  Vector3.one;
            else flyTransform.localScale = ParamFlySize.getParam() *  Vector3.one;
            if (ParamFlySpeed.getParam() == 0) speed = 0.05f;
            else speed = ParamFlySpeed.getParam() * 0.2f;
            if(SceneManager.GetActiveScene().name == "EditScene")
            {
                loadButton = GameObject.Find("LoadButton").GetComponent<Button>();
                loadButton.onClick.AddListener(LoadSettings);
            }
            else if(SceneManager.GetActiveScene().name == "MainScene")
            {
                flypath = SetImage.getFlySpritepath();
                StartCoroutine(getFlyLocalFile(flypath));
            }
            
            tongue = GameObject.Find("Tongue").GetComponent<Tongue>();
            if(GetComponent<SpriteRenderer>().sprite == null)
            {
                GetComponent<SpriteRenderer>().sprite = fly;
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
            // まっすぐ移動する
            transform.localPosition += direction * speed;
            if (flyType == "toLeftWave" || flyType == "toRightWave")
            {
                var temp = transform.localPosition;
                temp.y = Mathf.Sin(transform.localPosition.x);
                transform.localPosition = temp;
            }
            else if (flyType == "toLeftGiza" || flyType == "toRightGiza")
            {
                var temp = transform.localPosition;
                if (pos.y + 1 < temp.y) verticalDirection = "down";
                else if (pos.y -1 > temp.y) verticalDirection = "up";
                if (verticalDirection == "up") temp.y += 0.02f;
                else if (verticalDirection == "down") temp.y -= 0.02f;
                transform.localPosition = temp;
            }

            
        }
        private Vector3 pos;

        public void Init()
        {
            Debug.Log("Init");
            pos = Vector3.zero;
            flyType = type[Random.Range(0, type.Length)];
            switch (flyType)
            {
                case "toLeft":
                case "toLeftWave":
                case "toLeftGiza":
                    pos.x = base.respawnPosOutside.x;
                    pos.y = Random.Range(-base.respawnPosInside.y + 2.8f, base.respawnPosInside.y - 0.5f);
                    pos.z = 2.0f;
                    direction = Vector2.left;
                    break;
                case "toRight":
                case "toRightWave":
                case "toRightGiza":
                    pos.x = -base.respawnPosOutside.x;
                    pos.y = Random.Range(-base.respawnPosInside.y + 2.8f, base.respawnPosInside.y - 0.5f);
                    pos.z = 2.0f;
                    direction = Vector2.right;
                    Debug.Log("toRight");
                    StartCoroutine("DirectionChange");
                    break;
            }
            transform.localPosition = pos;
            //Debug.Log(scale);
            

            

        }
        IEnumerator  DirectionChange()
        {
            yield return new WaitForSeconds(0.2f);
            Vector3 scale = this.gameObject.transform.localScale;
            scale.x = -scale.x;
            this.gameObject.transform.localScale = scale;
            Debug.Log("Direction");
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Contains("TongueCollider"))
            {
                // Destroy(gameObject);
                // gameObject.AddComponent<FixedJoint2D>();
                // FixedJoint2D fixedJoint = GetComponent<FixedJoint2D>();
                // fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                // GetComponent <Rigidbody2D>().velocity = Vector3.zero;
                // GetComponent <Rigidbody2D>().Sleep ();
            }
        }

        private void LoadSettings()
        {
            if (ParamFlySpeed.getParam() == 0) rBody.gravityScale = 0.5f;
            else rBody.gravityScale = ParamFlySpeed.getParam();
        }

        public void onClickAct() 
        {
            tongue.Hitting(this.gameObject);
            Debug.Log("clickfly");
        }

        IEnumerator getFlyLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
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
                flysprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                GetComponent<SpriteRenderer>().sprite = flysprite;
                
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
