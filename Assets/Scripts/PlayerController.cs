using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        GameService.Instance.GetService<LoggerManager>()?.Log("v2");
    }
}
