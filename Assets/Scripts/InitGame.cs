using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    [SerializeField] private SceneInfoSO m_sceneInfoSO;

    async void Start()
    {
        // await AddressableHelper.LoadAsset(m_sceneInfoSO.obj.name);
    }
}
