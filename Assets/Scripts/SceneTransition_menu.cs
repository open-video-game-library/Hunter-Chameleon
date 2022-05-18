using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition_menu : MonoBehaviour
{
    private GameObject menuObject;
    private Button editorButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        menuObject = GameObject.Find("MenuObject");
        menuObject.SetActive(true);
        if(GameObject.Find("EditorButton") != null)
        {
            editorButton = GameObject.Find("EditorButton").GetComponent<Button>();
            editorButton.onClick.AddListener(GotoEditor);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //menuObject.SetActive(true);
    }
    void GotoEditor()
    {
        SceneManager.LoadScene("EditScene");
        //Application.LoadLevelAdditive("EditScene");
        //editObject.SetActive(true);
        menuObject.SetActive(false);
    }
        
    
}
