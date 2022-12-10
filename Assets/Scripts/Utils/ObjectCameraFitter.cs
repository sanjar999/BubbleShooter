﻿using UnityEngine;

public class ObjectCameraFitter : MonoBehaviour
{
    [SerializeField] private CameraFitType _cameraFitType;
    [SerializeField] private AspectFitType _aspectFitType;
    [SerializeField] private float _defaultAspect = 9f / 16f;
    [SerializeField] private CameraFitter _cameraFitter;
    [SerializeField] private Transform _object;

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

        var originalSize = _cameraFitter.OriginalSize;
        var newSize = _cameraFitter.NewSize;
        var direction = 0;

        switch (_cameraFitType)
        {
            case CameraFitType.Top:
                direction = currentAspect < _defaultAspect ? -1 : 1;
                break;
            case CameraFitType.Center:
                break;
            case CameraFitType.Bottom:
                direction = currentAspect < _defaultAspect ? 1 : -1;
                break;
        }
        _object.transform.position -= new Vector3(0f, direction * Mathf.Abs(originalSize - newSize));
    }
}
