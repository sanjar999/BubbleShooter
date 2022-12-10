using UnityEngine;

public class SafeAreaPanel : MonoBehaviour
{
    private RectTransform _panel;

    private void Awake()
    {
        _panel = GetComponent<RectTransform>();
        ApplySafeArea(Screen.safeArea);
    }

    private void ApplySafeArea(Rect r)
    {
        var anchorMin = r.position;
        var anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;
    }
}
