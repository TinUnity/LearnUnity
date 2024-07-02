using System;
using UnityEngine;

public class LoggerManager : MonoBehaviour, IGlobalService
{
    public bool isLogged;

    public void Log(string msg)
    {
        if(isLogged)
            Debug.Log($"<color=green> ☻: {msg}</color>");
    }
    
    public void LogWarning(string msg)
    {
        if(isLogged)
            Debug.Log($"<color=yellow> ⚠️: {msg}</color>");
    }
    
    public void LogError(string msg)
    {
        if(isLogged)
            Debug.Log($"<color=red> <b>!</b>: {msg}</color>");
    }
}
