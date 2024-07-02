using ProjectTools;
using UnityEngine;

public enum APIDomain
{
    Login,
    Register
}

[CreateAssetMenu(fileName = "APIDomain", menuName = "API/ListDomain")]
public class ApiDomainSO : ScriptableObject
{
    public SerializableDictionary<APIDomain, string> listDomainAPI = new();
}
