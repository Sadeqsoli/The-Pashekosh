
using UnityEngine;

public static class TexToSprite
{
    static Vector2 PivotPoints = new Vector2(0.5f, 0.5f);
    public static Sprite ConvertToSprite(this Texture2D texture )
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), PivotPoints);
    }

    //using for sprite renderer
    public static Sprite ConvertToSprite(this Texture2D texture, float ppu) 
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width , texture.height), PivotPoints, ppu);
    }
}