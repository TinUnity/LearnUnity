using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "CreateUIScreenObject")]
public class UIScreenSO : ScriptableObject
{
    public List<AssetReference> listAssetReference = new List<AssetReference>();
}
