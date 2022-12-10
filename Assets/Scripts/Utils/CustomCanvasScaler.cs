using UnityEngine;
using UnityEngine.UI;

public class CustomCanvasScaler : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float _wideMatch;
    [SerializeField][Range(0f, 1f)] private float _notWideMatch;

    private void Awake()
    {
        var canvas = GetComponent<CanvasScaler>();
        switch (ScreenUtils.GetScreeType())
        {
            case ScreenType.Wide:
                canvas.matchWidthOrHeight = _wideMatch;
                break;
            case ScreenType.NotWide:
                canvas.matchWidthOrHeight = _notWideMatch;
                break;
        }
    }
}
