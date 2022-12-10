using UnityEngine;

public enum ScreenOrientation
{
    Portrait,
    Landscape
}

public enum ScreenType
{
    Wide,
    NotWide
}

public static class ScreenUtils
{
    public static ScreenType GetScreeType()
    {
        var aspectRatio = (float)Screen.width / Screen.height;
        switch (GetScreenOrientation())
        {
            case ScreenOrientation.Portrait:
                if (aspectRatio <= 9f / 16f)
                {
                    return ScreenType.Wide;
                }
                else
                {
                    return ScreenType.NotWide;
                }
            case ScreenOrientation.Landscape:
                if (aspectRatio >= 16f / 9f)
                {
                    return ScreenType.Wide;
                }
                else
                {
                    return ScreenType.NotWide;
                }
        }
        return ScreenType.Wide;
    }

    public static ScreenOrientation GetScreenOrientation()
    {
        if (Screen.width > Screen.height)
        {
            return ScreenOrientation.Landscape;
        }
        else
        {
            return ScreenOrientation.Portrait;
        }
    }
}