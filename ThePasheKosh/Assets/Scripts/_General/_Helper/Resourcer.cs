using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public enum SpriteType { JPG,PNG }

public static class Resourcer
{
    #region Properties
    static string gif_FILE_EXTENSION { get { return GIF_FILE_EXTENSION; } }
    static string png_FILE_EXTENSION { get { return PNG_FILE_EXTENSION; } }
    static string mp3_FILE_EXTENSION { get { return MP3_FILE_EXTENSION; } }
    static string wav_FILE_EXTENSION { get { return WAV_FILE_EXTENSION; } }
    static string text_FILE_EXTENSION { get { return TEXT_FILE_EXTENSION; } }
    #endregion

    #region Fields
    static string GIF_FILE_EXTENSION = @".gif";
    static string PNG_FILE_EXTENSION = @".png";
    static string JPG_FILE_EXTENSION = @".jpg";
    static string MP3_FILE_EXTENSION = @".mp3";
    static string WAV_FILE_EXTENSION = @".wav";
    static string TEXT_FILE_EXTENSION = @".json";
    #endregion


    #region Public Methods
    public static string TextLoader(string path, string extention)
    {
        return ReturnTextResource(path, extention);
    }
    public static Texture2D TextureLoader(string path)
    {
        return ReturnTexture2DResource(path);
    }
    public static Sprite SpriteLoader(string path, SpriteType mediaType = SpriteType.PNG)
    {
        Sprite sprite = null;
        if(mediaType == SpriteType.PNG)
        {
            sprite =  ReturnPNGSpriteResource(path);
            return sprite;
        }
        else if (mediaType == SpriteType.JPG)
        {
            sprite = ReturnJPGSpriteResource(path);
            return sprite;
        }
        return sprite;
    }
    public static VideoClip VideoLoader(string path)
    {
        return ReturnVideoResource(path);
    }
    public static AudioClip Mp3Loader(string path)
    {
        return ReturnMP3Resource(path);
    }
    public static AudioClip[] ListOfClips(string path)
    {
        return ReturnAllMP3(path);
    }
    public static AudioClip WAVLoader(string path)
    {
        return ReturnWavResource(path);
    }
    #endregion

    #region Private Methods


    static string RemoveFileExtension(string path, string fileExtension)
    {
        string _FILE_EXTENSION = fileExtension;
        if (path.Length >= _FILE_EXTENSION.Length)
        {
            //If file extension exist, remove it.
            if (path.ToLower().Substring(path.Length - _FILE_EXTENSION.Length, _FILE_EXTENSION.Length) == _FILE_EXTENSION.ToLower())
                return path.Substring(0, path.Length - _FILE_EXTENSION.Length);
            //File extension doesn't exist.
            else
                return path;
        }
        //Path isn't long enough to contain file extension.
        else
        {
            return path;
        }
    }


    static string RemoveLeadingDirectorySeparator(string path)
    {
        //Remove directory separate character if it exist on the first character.
        if (char.Parse(path.Substring(0, 1)) == Path.DirectorySeparatorChar || char.Parse(path.Substring(0, 1)) == Path.AltDirectorySeparatorChar)
            return path.Substring(1);
        else
            return path;
    }


    static string ReturnTextResource(string path, string extention)
    {
        //Remove default file extension and format the path to the platform.
        path = RemoveFileExtension(path, extention);
        path = RemoveLeadingDirectorySeparator(path);

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return string.Empty;
        }

        //Try to load text from file path.
        TextAsset textAsset = Resources.Load(path) as TextAsset;

        if (textAsset != null)
            return textAsset.text;
        else
            return string.Empty;
    }




    static Texture2D ReturnTexture2DResource(string path)
    {
        if (path.EndsWith(PNG_FILE_EXTENSION))
        {
            //Remove default file extension and format the path to the platform.
            path = RemoveFileExtension(path, PNG_FILE_EXTENSION);
            path = RemoveLeadingDirectorySeparator(path);
        }
        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }
        //Try to load sprite from file path.
        Texture2D textureAsset = Resources.Load<Texture2D>(path) as Texture2D;

        if (textureAsset != null)
            return textureAsset;
        else
            return null;
    }

    static Sprite ReturnJPGSpriteResource(string path)
    {
        if (path.EndsWith(JPG_FILE_EXTENSION))
        {
            //Remove default file extension and format the path to the platform.
            path = RemoveFileExtension(path, JPG_FILE_EXTENSION);
            path = RemoveLeadingDirectorySeparator(path);
        }
        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }
        //Try to load sprite from file path.
        Sprite spriteAsset = Resources.Load<Sprite>(path) as Sprite;

        if (spriteAsset != null)
            return spriteAsset;
        else
            return null;
    }
    static Sprite ReturnPNGSpriteResource(string path)
    {
        if (path.EndsWith(PNG_FILE_EXTENSION))
        {
            //Remove default file extension and format the path to the platform.
            path = RemoveFileExtension(path, PNG_FILE_EXTENSION);
            path = RemoveLeadingDirectorySeparator(path);
        }
        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }
        //Try to load sprite from file path.
        Sprite spriteAsset = Resources.Load<Sprite>(path) as Sprite;

        if (spriteAsset != null)
            return spriteAsset;
        else
            return null;
    }


    static VideoClip ReturnVideoResource(string path)
    {
        if (path.EndsWith(GIF_FILE_EXTENSION))
        {
            //Remove default file extension and format the path to the platform.
            path = RemoveFileExtension(path, GIF_FILE_EXTENSION);
            path = RemoveLeadingDirectorySeparator(path);
        }

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }
        //Try to load videoClip from file path.
        VideoClip videoAsset = Resources.Load<VideoClip>(path) as VideoClip;

        if (videoAsset != null)
            return videoAsset;
        else
            return null;

    }

    static AudioClip ReturnMP3Resource(string path)
    {
        //Remove default file extension and format the path to the platform.
        path = RemoveFileExtension(path, MP3_FILE_EXTENSION);
        path = RemoveLeadingDirectorySeparator(path);

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }

        //Try to load AudioClip from file path.
        AudioClip audioAsset = Resources.Load(path) as AudioClip;

        if (audioAsset != null)
            return audioAsset;
        else
            return null;
    }
    static AudioClip[] ReturnAllMP3(string path)
    {
        //Remove default file extension and format the path to the platform.
        path = RemoveLeadingDirectorySeparator(path);

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }

        //Try to load AudioClip from file path.
        AudioClip[] audioAsset = Resources.LoadAll(path) as AudioClip[];

        if (audioAsset != null)
            return audioAsset;
        else
            return null;
    }

    static AudioClip ReturnWavResource(string path)
    {
        //Remove default file extension and format the path to the platform.
        path = RemoveFileExtension(path, WAV_FILE_EXTENSION);
        path = RemoveLeadingDirectorySeparator(path);

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return null;
        }

        //Try to load AudioClip from file path.
        AudioClip audioAsset = Resources.Load(path) as AudioClip;

        if (audioAsset != null)
            return audioAsset;
        else
            return null;
    }

    #endregion


}//EndClasssssss
