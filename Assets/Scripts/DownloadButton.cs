using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadButton : MonoBehaviour
{
    DataManager dataManager;

    void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
    }
    public void OnClickButton()
    {
        dataManager.getData();
    }
}
