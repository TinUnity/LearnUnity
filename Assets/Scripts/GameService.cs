using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;

public sealed class GameService : ServiceManager
{
    void Awake()
    {
        RegisterServices();
    }
    
    private void LocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
    {
        foreach (var item in obj.Result)
        {
            Addressables.InstantiateAsync(item);
        }
    }

    void RegisterServices()
    {
        var services = FindObjectsOfType<MonoBehaviour>(true).OfType<IGlobalService>();
        foreach (var item in services)
        {
            base.RegisterService(item, () =>
            {
                var monoItem = item as MonoBehaviour;
                if(monoItem) monoItem.transform.SetParent(this.transform);
            });
        }
    }
}
