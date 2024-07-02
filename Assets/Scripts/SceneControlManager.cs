using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour, IGlobalService
{
    [SerializeField] private SceneInfoSO m_sceneInfoSo;
    public void TransitionScene(string a,LoadSceneMode loadMode = LoadSceneMode.Single)
    {
        // SceneManager.LoadSceneAsync(sceneName.ToString(),loadMode);
        // _sceneList = sceneList;
    }
}
