using UnityEngine;

public enum CameraFitType
{
    Top,
    Center,
    Bottom
}

public enum AspectFitType
{
    OnlyWide,
    OnlyNotWide,
    Both
}

public class CameraFitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraFitType _cameraFitType;
    [SerializeField] private AspectFitType _aspectFitType;
    [SerializeField] private float _defaultAspect = 9f / 16f;

    public float OriginalSize { get; private set; }
    public float NewSize { get; private set; }
    public int Direction { get; private set; }

    private void Start()
    {
        var currentAspect = (float)Screen.width / Screen.height;

        switch (_aspectFitType)
        {
            case AspectFitType.OnlyWide:
                if (currentAspect > _defaultAspect)
                    return;
                break;
            case AspectFitType.OnlyNotWide:
                if (currentAspect <= _defaultAspect)
                    return;
                break;
            case AspectFitType.Both:
                break;
        }

        OriginalSize = _camera.orthographicSize;
        NewSize = _camera.orthographicSize * _defaultAspect / currentAspect;
        _camera.orthographicSize = NewSize;

        switch (_cameraFitType)
        {
            case CameraFitType.Top:
                Direction = currentAspect < _defaultAspect ? -1 : 1;
                break;
            case CameraFitType.Center:
                break;
            case CameraFitType.Bottom:
                Direction = currentAspect < _defaultAspect ? 1 : -1;
                break;
        }
        _camera.transform.position += new Vector3(0f, Direction * Mathf.Abs(OriginalSize - NewSize));
    }
}