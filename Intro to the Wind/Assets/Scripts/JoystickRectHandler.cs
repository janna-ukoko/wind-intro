using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class JoystickRectHandler : MonoBehaviour
{
    [SerializeField] private RectTransform baseRect = null;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        baseRect.sizeDelta = new Vector2(canvas.pixelRect.width, canvas.pixelRect.height);
    }

    void Update()
    {
#if UNITY_EDITOR
        baseRect.sizeDelta = new Vector2(canvas.pixelRect.width, canvas.pixelRect.height);
#endif
    }
}
