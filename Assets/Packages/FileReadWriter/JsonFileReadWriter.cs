using UnityEngine;
using System.IO;

// NOTE:
// ~X function use DataContractJsonSerializer.
// However, it is not recommended.

public static class JsonFileReadWriter
{
    public static TextFileIOResult WriteJsonToStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        string path = ToJsonFilePath(dir, file ?? obj.GetType().ToString());

        return TextFileReadWriter.WriteToStreamingAssets(path, JsonUtility.ToJson(obj));
    }

    public static TextFileIOResult WriteJsonToStreamingAssetsX<T>(T obj, string dir = null, string file = null)
    {
        string path = ToJsonFilePath(dir, file ?? obj.GetType().ToString());

        return TextFileReadWriter.WriteToStreamingAssets(path, DataContractJsonUtility.ToJson(obj));
    }

    public static TextFileIOResult WriteJsonToFile<T>(T obj, string dir = null, string file = null)
    {
        string path = ToJsonFilePath(dir, file ?? obj.GetType().ToString());

        return TextFileReadWriter.WriteToFile(path, JsonUtility.ToJson(obj));
    }

    public static TextFileIOResult WriteJsonToFileX<T>(T obj, string file = null, string dir = null)
    {
        string path = ToJsonFilePath(dir, file ?? obj.GetType().ToString());

        return TextFileReadWriter.WriteToFile(path, DataContractJsonUtility.ToJson(obj));
    }

    public static T ReadJsonFromStreamingAssets<T>(string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromStreamingAssets(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            return JsonUtility.FromJson<T>(ioResult.text);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
            return default;
        }
    }

    public static void ReadJsonFromStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromStreamingAssets(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            JsonUtility.FromJsonOverwrite(ioResult.text, obj);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
        }
    }

    public static T ReadJsonFromStreamingAssetsX<T>(string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromStreamingAssets(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            return DataContractJsonUtility.FromJson<T>(ioResult.text);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
            return default;
        }
    }

    public static T ReadJsonFromFile<T>(string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromFile(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            return JsonUtility.FromJson<T>(ioResult.text);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
            return default;
        }
    }

    public static void ReadJsonFromFile<T>(T obj, string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromFile(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            JsonUtility.FromJsonOverwrite(ioResult.text, obj);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
        }
    }

    public static T ReadJsonFromFileX<T>(string dir = null, string file = null)
    {
        TextFileIOResult ioResult = TextFileReadWriter.ReadFromFile(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (ioResult.isSuccess)
        {
            return DataContractJsonUtility.FromJson<T>(ioResult.text);
        }
        else
        {
            Debug.LogWarning(ioResult.text);
            return default;
        }
    }

    private static string ToJsonFilePath(string dir, string file)
    {
        string path = "";

        if (dir == null || dir.Length == 0)
        {
            path = "/";
        }
        else
        {
            if (dir[dir.Length - 1] != '/')
            {
                dir += "/";
            }

            path = dir;
        }

        path = path + (file ?? "") + ".json";

        return path;
    }
}