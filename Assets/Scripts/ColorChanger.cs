using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        ClickManager.OnButtonClicked += ChangeColor;
    }

    void ChangeColor(int val)
    {
        Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };
        rend.material.color = colors[val - 1];
    }

    void OnDestroy()
    {
        ClickManager.OnButtonClicked -= ChangeColor;
    }
}
