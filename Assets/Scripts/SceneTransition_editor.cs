using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition_editor : MonoBehaviour
{
    private Button homeButton;
    private Button editorButton;
    private GameObject editObject;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        if(GameObject.Find("HomeButton") != null)
        {
            homeButton = GameObject.Find("HomeButton").GetComponent<Button>();
            homeButton.onClick.AddListener(GotoHome);
        }
        editObject =GameObject.Find("EditObject");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GotoHome()
    {
        SceneManager.LoadScene("MenuScene");
        //Application.LoadLevelAdditive("MenuScene");
        editObject.SetActive(false);
    }

    
}
