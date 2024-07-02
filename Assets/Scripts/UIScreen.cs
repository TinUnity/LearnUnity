using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas),typeof(CanvasScaler))]
[RequireComponent(typeof(GraphicRaycaster))]
public class UIScreen : MonoBehaviour
{
    [SerializeField] protected UIScreenSO uiScreenSo;

    protected void Awake()
    {
        Addressables.InitializeAsync().Completed += objects =>
        {
            foreach (var assetReference in uiScreenSo.listAssetReference)
            {
                AddressableHelper.LoadAssetReference(assetReference, (obj) =>
                {
                    obj.transform.SetParent(this.transform);
                });
            }
        };   
    }
}
