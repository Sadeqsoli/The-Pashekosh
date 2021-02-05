using UnityEngine;


public static class CameraScaler 
{

    static Camera mainCamera = Camera.main;


    public static void SetCameraByWidth(SpriteRenderer sprite)
    {
        mainCamera.orthographicSize = sprite.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
    public static void SetCameraByHeight(SpriteRenderer sprite)
    {
        mainCamera.orthographicSize = sprite.bounds.size.y / 2;
    }
    public static void CameraFit(SpriteRenderer sprite)
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = sprite.bounds.size.x / sprite.bounds.size.y;

        if (screenRatio <= targetRatio)
        {
            mainCamera.orthographicSize = sprite.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            mainCamera.orthographicSize = sprite.bounds.size.y / 2 * differenceInSize;
        }
    }


}
