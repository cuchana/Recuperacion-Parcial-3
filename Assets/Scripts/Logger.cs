using UnityEngine;

public class Logger : MonoBehaviour
{
    void OnEnable() => ClickManager.OnButtonClicked += Log;
    void OnDisable() => ClickManager.OnButtonClicked -= Log;

    void Log(int val)
    {
        Debug.Log("Color actual: " + val);
    }
}
