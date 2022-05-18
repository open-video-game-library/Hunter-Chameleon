using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Chameleon
{
    public class MainController : MonoBehaviour
    {
        public GameObject apple;
        public GameObject bee;
        public GameObject fly;

        private string appleSpritepath;
        private string beeSpritepath;
        private string flySpritepath;
        private Sprite applesprite;
        private Sprite beesprite;

        private Sprite flysprite;

        // Start is called before the first frame update
        void Start()
        {
            appleSpritepath = SetImage.getAppleSpritepath();
            StartCoroutine(getAppleLocalFile(appleSpritepath));
            StartCoroutine(getBeeLocalFile(beeSpritepath));
            StartCoroutine(getFlyLocalFile(flySpritepath));
            //StartCoroutine(getStageLocalFile(_inputStagePathText));
        }

        // Update is called once per frame
        void Update()
        {
            
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
                apple.GetComponent<SpriteRenderer>().sprite = applesprite;
                
                for(int i=0;i<6;i++)
                {
                    if(apple.GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(apple.GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        apple.AddComponent<PolygonCollider2D>();
                    }
                }
                    //DestroyImmediate(apple.GetComponent<PolygonCollider2D>(),true);
                    
                
            
                
                //goRawImage.GetComponent<Rigidbody2D>().sharedMaterial = physicmaterial2D;
                // goRawImage.GetComponent<BoxCollider2D>() = physicmaterial2D;
            }


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
                bee.GetComponent<SpriteRenderer>().sprite = beesprite;
                
                for(int i=0;i<6;i++)
                {
                    if(bee.GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(bee.GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        bee.AddComponent<PolygonCollider2D>();
                    }
                }
                    //DestroyImmediate(apple.GetComponent<PolygonCollider2D>(),true);
                    
                
            
                
                //goRawImage.GetComponent<Rigidbody2D>().sharedMaterial = physicmaterial2D;
                // goRawImage.GetComponent<BoxCollider2D>() = physicmaterial2D;
            }


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
                fly.GetComponent<SpriteRenderer>().sprite = flysprite;
                
                for(int i=0;i<6;i++)
                {
                    if(fly.GetComponent<PolygonCollider2D>() != null)
                    DestroyImmediate(fly.GetComponent<PolygonCollider2D>(),true);

                    if(i == 5)
                    {
                        fly.AddComponent<PolygonCollider2D>();
                    }
                }
                    //DestroyImmediate(apple.GetComponent<PolygonCollider2D>(),true);
                    
                
            
                
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
