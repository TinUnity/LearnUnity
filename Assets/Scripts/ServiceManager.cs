using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : SingletonManager<ServiceManager>
{
    protected Dictionary<string, object> dicService = new Dictionary<string, object>();
    
    protected void RegisterService(object service, Action callback)
    {
        var nameService = service.GetType().Name;
        if (!dicService.ContainsKey(nameService))
        {
            dicService.Add(nameService, service);
            Debug.Log($"Added Service ====> {nameService}");
            callback?.Invoke();
        }
    }

    public T GetService<T>() where T : class
    {
        var service = typeof(T);
        if (!dicService.ContainsKey(service.Name) || string.IsNullOrEmpty(service.Name))
        {
            Debug.Log($"Has No Service ====> {service.Name}");
            return null;
        }

        if (dicService.TryGetValue(service.Name, out object obj))
        {
            return obj as T;
        }

        throw new ArgumentException($"Found No Service: {service.Name}");
    }
}
