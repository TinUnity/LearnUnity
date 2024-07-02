using System;
using CoolishHttp;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class HttpHelper : MonoBehaviour
{
    public static void GetHTTP(APIDomain apiDomain, Action<HttpResponse> onSuccess, Action onError)
    {
        var urlAPI = GameService.Instance.GetService<ConfigHostingManager>().GetConfigAPI(apiDomain);
        SimpleHttpClient.Get(urlAPI).OnSuccess(res => onSuccess?.Invoke(res))
            .OnError(err => onError?.Invoke())
            .Send();
    }
    
    public static void PostHTTP<T>(APIDomain apiDomain, T jsonData ,Action<HttpResponse> onSuccess, Action onError)
    {
        var urlAPI = GameService.Instance.GetService<ConfigHostingManager>().GetConfigAPI(apiDomain);
        SimpleHttpClient.PostJson(urlAPI,JsonConvert.SerializeObject(jsonData))
            .OnSuccess(res => onSuccess?.Invoke(res))
            .OnError(err => onError?.Invoke())
            .Send();
    }
}
