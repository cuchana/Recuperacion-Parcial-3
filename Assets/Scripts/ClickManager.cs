using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static event Action<int> OnButtonClicked;
    private int counter = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter = (counter % 4) + 1;
            OnButtonClicked?.Invoke(counter);
        }
    }
}
