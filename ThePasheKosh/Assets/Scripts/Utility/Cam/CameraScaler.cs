using UnityEngine;


public static class CameraScaler 
{
    #region Properties

    #endregion

    #region Fields

    #endregion

    #region Public Methods
    #endregion





    #region Private Methods


    public static void SetCameraByWidth(SpriteRenderer sprite)
    {
        Camera.main.orthographicSize = sprite.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
    public static void SetCameraByHeight(SpriteRenderer sprite)
    {
        Camera.main.orthographicSize = sprite.bounds.size.y / 2;
    }
    public static void CameraFit(SpriteRenderer sprite)
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = sprite.bounds.size.x / sprite.bounds.size.y;

        if (screenRatio <= targetRatio)
        {
            Camera.main.orthographicSize = sprite.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = sprite.bounds.size.y / 2 * differenceInSize;
        }
    }




    #endregion
}
