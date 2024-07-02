using UnityEngine;

[CreateAssetMenu(fileName = "ConfigHostingData", menuName = "Server/ConfigHostingData")]
public class ConfigHostingDataSO : ScriptableObject
{
    public string apiHosting;
    public string assetsHosting;
    public ApiDomainSO apiDomainS0;

    public string GetAPI(APIDomain apiDomain)
    {
        var apiUrl = apiDomainS0.listDomainAPI[apiDomain];
        var url = string.Format("{0}{1}",apiHosting,apiUrl);
        return url;
    }
}
