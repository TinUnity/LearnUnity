using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour,IGlobalService
{
    private CoroutineManager _instance;
    void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

    public Coroutine StartManagedCoroutine(IEnumerator coroutine)
    {
        return _instance.StartCoroutine(coroutine);
    }
    
    public void StopManagedCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void StopAllManagedCoroutines()
    {
        StopAllCoroutines();
    }

}
