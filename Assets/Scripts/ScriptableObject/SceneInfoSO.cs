using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneSO/Create")]
public class SceneInfoSO : ScriptableObject
{
    public List<string> listScene = new List<string>();
}
