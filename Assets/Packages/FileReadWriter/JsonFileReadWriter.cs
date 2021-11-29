using System.IO;
using UnityEngine;

public static class JsonFileReadWriter
{
    public static (string json, bool success) WriteJsonToStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        return TextFileReadWriter.WriteToStreamingAssets(Path.Combine(dir, file), JsonUtility.ToJson(obj));
    }
    
    public static (string json, bool success) WriteJsonToFile<T>(T obj, string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        return TextFileReadWriter.WriteToFile(Path.Combine(dir, file), JsonUtility.ToJson(obj));
    }
    
    public static (T data, bool success) ReadJsonFromStreamingAssets<T>(string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        var (text, success) = TextFileReadWriter.ReadFromStreamingAssets(Path.Combine(dir, file));

        if (success)
        {
            return (JsonUtility.FromJson<T>(text), true);
        }
        else
        {
            Debug.LogWarning(text);
            return (default, false);
        }
    }

    public static void ReadJsonFromStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        var (text, success) = TextFileReadWriter.ReadFromStreamingAssets(Path.Combine(dir, file));

        if (success)
        {
            JsonUtility.FromJsonOverwrite(text, obj);
        }
        else
        {
            Debug.LogWarning(text);
        }
    }
    
    public static (T data, bool success) ReadJsonFromFile<T>(string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        var (text, success) = TextFileReadWriter.ReadFromFile(Path.Combine(dir, file));

        if (success)
        {
            return (JsonUtility.FromJson<T>(text), true);
        }
        else
        {
            Debug.LogWarning(text);
            return (default, false);
        }
    }

    public static void ReadJsonFromFile<T>(T obj, string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        var (text, success) = TextFileReadWriter.ReadFromFile(Path.Combine(dir, file));

        if (success)
        {
            JsonUtility.FromJsonOverwrite(text, obj);
        }
        else
        {
            Debug.LogWarning(text);
        }
    }
}