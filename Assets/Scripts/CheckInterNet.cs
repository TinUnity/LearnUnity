using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CheckInterNet : MonoBehaviour
{
    [DllImport("__Internal")] 
    private static extern void saveDataToIndexedDB(string dbName,string storeName,string key, string value);
    [DllImport("__Internal")]
    private static extern void loadDataFromIndexedDB(string dbName,string storeName,string key);
        
    [SerializeField] private Button mBtnLoadDB;
    [SerializeField] private Button mBtnSaveDB;
    
    [SerializeField] private Button mBtnCheck;
    [SerializeField] private Text mTxtCheck;

    private void Start()
    {
        mBtnCheck.onClick.AddListener(OnCheckInternet);
        mBtnLoadDB.onClick.AddListener(OnLoadIndexDB);
        mBtnSaveDB.onClick.AddListener(OnSaveIndexDB);
    }

    void OnShowText(string mess)
    {
        mTxtCheck.text = mess;
    }

    public void OnCheckInternet()
    {
#if UNITY_WEBGL
        Application.ExternalCall("checkNetworkStatus");
#endif
    }
    
    public void OnSaveIndexDB()
    {
#if UNITY_WEBGL
        saveDataToIndexedDB("myDatabase", "myStore", "mIndex", "TESTGGO");
#endif
    }

    public void OnLoadIndexDB()
    {
#if UNITY_WEBGL
        loadDataFromIndexedDB("myDatabase", "myStore", "mIndex");
#endif
    }
}
