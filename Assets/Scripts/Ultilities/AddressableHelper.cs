using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = System.Object;

public class AddressableHelper
{
    public static async UniTask DownloadContentCatalog(string urlPath,Action callback = null)
    {
        AsyncOperationHandle<IResourceLocator> async = Addressables.LoadContentCatalogAsync(urlPath,true);
        await async.ToUniTask();
        if (async.Status == AsyncOperationStatus.Succeeded)
        {
            callback?.Invoke();
        }
        else
        {
            var logService = GameService.Instance.GetService<LoggerManager>();
            if (logService) logService.LogError("Load Content Failed");
            else Debug.LogError("Load Content Failed");
        }
    }
    
    public static async UniTask<GameObject> LoadAsset(string keyAsset)
    {
        var async = Addressables.InstantiateAsync(keyAsset);
        await async.ToUniTask();
        if (async.Status == AsyncOperationStatus.Succeeded) return async.Result;
        else
        {
            Debug.LogError("Can't Load Asset");
            return null;
        }
        // callback?.Invoke();
        // else
        // {
        //     var logService = GameService.Instance.GetService<LoggerManager>();
        //     if (logService) logService.LogError("Load Content Failed");
        //     else Debug.LogError("Load Content Failed");
        // }
    }

    public static async UniTask<IList<GameObject>> LoadAssets(string keyAssets)
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>(keyAssets, obj =>
        {
            //Gets called for every loaded asset
            Debug.Log(obj.name);
        });

        await handle.ToUniTask();
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            IList<GameObject> results = handle.Result;
            return results;
        }
        else
            return null;
    }

    public static void LoadAssetReference(AssetReference assetReference, Action<GameObject> callback)
    {
        var handle = assetReference.LoadAssetAsync<GameObject>();
        handle.Completed += operationHandle =>
        {
            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(operationHandle.Result);
            }
            else
            {
                Debug.LogError("Load AssetReference Failed");
            }
        };
    }
}
