using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Chameleon
{
    public class SetImage : MonoBehaviour
    {
        public string PrefabPath;

        private Button _imageLoadButton;
        public  static string _inputBeePathText;
        //public static string beepath ="";
        public static string _inputApplePathText;
        public static string _inputFlyPathText;
        public static string _inputAimPathText;
        public static string _inputStagePathText;
        public string _inputBGMPathText;
        public string _inputReticlePathText;
        public PhysicsMaterial2D physicmaterial2D;
        private Slider beescaleSlider;
        private Slider applescaleSlider;
        private Slider flyscaleSlider;
        private Slider aimscaleSlider;
        public GameObject bee;
        public GameObject apple;
        public GameObject fly;
        public GameObject aim;
        public GameObject stage;
        public GameObject forest;
        public GameObject loadButton;
        public GameObject beescale;
        public GameObject applescale;
        public GameObject flyscale;
        public GameObject aimscale;
        public GameObject instance;  // �V�[�����̃C���X�^���X
        private  Sprite applesprite;
        private  Sprite beesprite;
        private  Sprite flysprite;
        public Toggle toggle;
        public  static bool defaultStage =true;
        private AudioSource BGM;
        //public static string 

        //public GameObject prefab;    // �v���W�F�N�g�r���[���̃v���n�u

        // Start is called before the first frame update
        void Start()
        {
            _imageLoadButton = GameObject.Find("LoadButton").GetComponent<Button>();
            //_imageLoadButton = loadButton.GetComponent<Button>();
            _imageLoadButton.onClick.AddListener(LoadButtonClick);
            //goRawImage = GameObject.Find("Bee");
            beescaleSlider = beescale.GetComponent<Slider>();
            applescaleSlider = applescale.GetComponent<Slider>();
            flyscaleSlider = flyscale.GetComponent<Slider>();
            aimscaleSlider = aimscale.GetComponent<Slider>();
            // DontDestroyOnLoad(bee);

            BGM = GameObject.Find("BGM Default").GetComponent<AudioSource>();
            
            if(_inputApplePathText != null)
            StartCoroutine(getAppleLocalFile(getAppleSpritepath()));
            if(_inputBeePathText != null)
            StartCoroutine(getBeeLocalFile(getBeeSpritepath()));
            if(_inputFlyPathText != null)
            StartCoroutine(getFlyLocalFile(getFlySpritepath()));
            if(_inputStagePathText != null)
            StartCoroutine(getStageLocalFile(getStageSpritepath()));
        }

        // Update is called once per frame
        void Update()
        {
            if(bee != null)
                bee.transform.localScale = Vector3.one * beescaleSlider.value ;
            if (apple != null)
                apple.transform.localScale = Vector3.one * applescaleSlider.value;
            if (fly != null)
                fly.transform.localScale = Vector3.one * flyscaleSlider.value;
            if (aim != null)
                aim.transform.localScale = Vector3.one * aimscaleSlider.value;
            

        }

        private void RestorePath()
        {
            _inputBeePathText = GameObject.Find("BeePathText").GetComponent<Text>().text;
            _inputApplePathText = GameObject.Find("ApplePathText").GetComponent<Text>().text;
            _inputFlyPathText = GameObject.Find("FlyPathText").GetComponent<Text>().text;
            _inputStagePathText = GameObject.Find("StagePathText").GetComponent<Text>().text;
            _inputBGMPathText = GameObject.Find("BGMPathText").GetComponent<Text>().text;

            StartCoroutine(getBeeLocalFile(_inputBeePathText));
            StartCoroutine(getAppleLocalFile(_inputApplePathText));
            StartCoroutine(getFlyLocalFile(_inputFlyPathText));
            StartCoroutine(getStageLocalFile(_inputStagePathText));
            if (_inputBGMPathText != null)
            StartCoroutine(StreamPlayAudioFile(_inputBGMPathText));
        }

        private void LoadButtonClick()
        {
            RestorePath();
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
                    //DestroyImmediate(bee.GetComponent<PolygonCollider2D>(),true);
                    
                
            
                
                //goRawImage.GetComponent<Rigidbody2D>().sharedMaterial = physicmaterial2D;
                // goRawImage.GetComponent<BoxCollider2D>() = physicmaterial2D;
            }


        }

        private void Reset() 
        {
            //apple.GetComponent<SpriteRenderer>().sprite = applesprite;
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
                //applesprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                applesprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), new Vector2(0.5f,0.5f));

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
            }


        }


        IEnumerator getAimLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
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
                Sprite sprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                aim.GetComponent<SpriteRenderer>().sprite = sprite;
                
                //goRawImage.GetComponent<Rigidbody2D>().sharedMaterial = physicmaterial2D;
                // goRawImage.GetComponent<BoxCollider2D>() = physicmaterial2D;
            }


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
                    stage.GetComponent<Image>().enabled = true;
                }
                Texture2D tex2d = ToTexture2D(tex);
                Sprite sprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), Vector2.zero);
                stage.GetComponent<Image>().sprite = sprite;
                forest.SetActive(false);
                
            }

        }

        IEnumerator getReticleLocalFile(string filename) //filename�ɂ̓t�H���_���܂߂ăR�[��
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
                Sprite sprite = Sprite.Create(tex2d, new Rect(-tex2d.width/2, -tex2d.height/2, tex2d.width, tex2d.height), Vector2.zero);
                aim.GetComponent<SpriteRenderer>().sprite = sprite;
                
            }

        }

        IEnumerator StreamPlayAudioFile(string fileName)
        {
            //ソース指定し音楽流す
            //音楽ファイルロード
            //if (fileName == null || fileName == "") return;
            if (fileName == " ") 
            {
                using(WWW www = new WWW("file:///" + fileName))
                {
                    //読み込み完了まで待機
                    yield return www;

                    if (www.GetAudioClip(true, true) != null)
                    BGM.clip = www.GetAudioClip(true, true);

                    BGM.Play();
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
            var source = new Rect(0,0, rt.width, rt.height);
            result.ReadPixels(source, 0, 0);
            result.Apply();
            RenderTexture.active = currentRT;
            return result;
        }

        public void OnToggleChanged()
        {

            //�uisOn�v�̓`�F�b�N�̏�Ԃ�\�����m�Btrue�Ȃ�uON�v�Afalse�Ȃ�uOFF�v��\���B
            defaultStage = toggle.isOn ? true : false;
        }

        public static bool getHitPoint()    //�X�^�[�g���ɌĂ�
        {
            return defaultStage;
        }

        void OnApplicationQuit()
        {
            Reset();
        }

        public static string getAppleSpritepath()
        {
            //beepath = _inputApplePathText;
            return _inputApplePathText;
        }
        public static string getBeeSpritepath()
        {
            //beepath = _inputApplePathText;
            return _inputBeePathText;
        }
        public static string getFlySpritepath()
        {
            return _inputFlyPathText;
        }
        public static string getStageSpritepath()
        {
            return _inputStagePathText;
        }


    }
}
