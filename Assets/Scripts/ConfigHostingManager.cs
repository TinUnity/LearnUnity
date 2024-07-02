using System;
using ProjectTools;
using UnityEngine;

public enum Config{
    Staging,
    Production
}
public class ConfigHostingManager : MonoBehaviour
{
    public Config configServer;

    public SerializableDictionary<Config,ConfigHostingDataSO> dicHosting;

    public string GetConfigAPI(APIDomain apiDomain)
    {
        var urlAPI = dicHosting[configServer].GetAPI(apiDomain);
        return urlAPI;
    }
}
