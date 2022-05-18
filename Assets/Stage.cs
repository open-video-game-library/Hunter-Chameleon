using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Chameleon
{
    public class Stage : MonoBehaviour
    {
        private string stagepath;
        public GameObject forest;

        // Start is called before the first frame update
        void Start()
        {
            if(SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "MenuScene")
            {
                stagepath = SetImage.getStageSpritepath();
                StartCoroutine(getStageLocalFile(stagepath));
            }
            else if(SceneManager.GetActiveScene().name == "EditScene")
            {
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        IEnumerator getStageLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
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
                if(tex != null)
                {
                    GetComponent<Image>().enabled = true;
                    forest.SetActive(false);
                }
                Texture2D tex2d = ToTexture2D(tex);
                Sprite sprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                GetComponent<Image>().sprite = sprite;
                
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
            var source = new Rect(0,0, rt.width, rt.height);
            result.ReadPixels(source, 0, 0);
            result.Apply();
            RenderTexture.active = currentRT;
            return result;
        }
    }
}

