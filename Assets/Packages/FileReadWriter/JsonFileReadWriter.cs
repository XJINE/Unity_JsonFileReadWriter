using System.IO;
using UnityEngine;

public static class JsonFileReadWriter
{
    public static (T data, bool success) ReadFromAssets<T>(string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        return Read<T>(Path.Combine(Application.dataPath, dir, file), true);
    }

    public static (T data, bool success) ReadFromStreamingAssets<T>(string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        return Read<T>(Path.Combine(Application.streamingAssetsPath, dir, file), true);
    }

    public static (T data, bool success) Read<T>(string dir = null, string file = null)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        return Read<T>(Path.Combine(dir, file), true);
    }

    public static (T data, bool success) Read<T>(string path, bool forceExtension = true)
    {
        if (forceExtension && !path.EndsWith(".json"))
        {
            path += ".json";
        }

        var (text, success) = TextFileReadWriter.Read(path);

        return success ? (JsonUtility.FromJson<T>(text), true) : (default, false);
    }

    public static void ReadFromAssets<T>(T obj)
    {
        Read(Path.Combine(Application.dataPath, typeof(T).Name + ".json"), obj);
    }

    public static void ReadFromAssets<T>(string dir, T obj)
    {
        dir ??= "";
        Read(Path.Combine(Application.dataPath, dir, typeof(T).Name + ".json"), obj);
    }

    public static void ReadFromAssets<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        Read(Path.Combine(Application.dataPath, dir, file), obj);
    }

    public static void ReadFromStreamingAssets<T>(T obj)
    {
        Read(Path.Combine(Application.streamingAssetsPath, typeof(T).Name + ".json"), obj);
    }

    public static void ReadFromStreamingAssets<T>(string dir, T obj)
    {
        dir ??= "";
        Read(Path.Combine(Application.streamingAssetsPath, dir, typeof(T).Name + ".json"), obj);
    }

    public static void ReadFromStreamingAssets<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        Read(Path.Combine(Application.streamingAssetsPath, dir, file), obj);
    }

    public static void Read<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";
        Read(Path.Combine(dir, file), obj);
    }

    public static void Read<T>(string path, T obj, bool forceExtension = true)
    {
        if (forceExtension && !path.EndsWith(".json"))
        {
            path += ".json";
        }

        var (text, success) = TextFileReadWriter.Read(path);

        if (success)
        {
            JsonUtility.FromJsonOverwrite(text, obj);
        }
    }

    public static (string json, bool success) WriteToAssets<T>(T obj)
    {
        return Write(Path.Combine(Application.dataPath, typeof(T).Name + ".json"), obj);
    }

    public static (string json, bool success) WriteToAssets<T>(string dir, T obj)
    {
        dir ??= "";
        return Write(Path.Combine(Application.dataPath, dir, typeof(T).Name + ".json"), obj);
    }

    public static (string json, bool success) WriteToAssets<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        return Write(Path.Combine(Application.dataPath, dir, file), obj);
    }

    public static (string json, bool success) WriteToStreamingAssets<T>(T obj)
    {
        return Write(Path.Combine(Application.streamingAssetsPath, typeof(T).Name + ".json"), obj);
    }

    public static (string json, bool success) WriteToStreamingAssets<T>(string dir, T obj)
    {
        dir ??= "";
        return Write(Path.Combine(Application.streamingAssetsPath, dir, typeof(T).Name + ".json"), obj);
    }

    public static (string json, bool success) WriteToStreamingAssets<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        return Write(Path.Combine(Application.streamingAssetsPath, dir, file), obj);
    }

    public static (string json, bool success) Write<T>(string dir, string file, T obj)
    {
        dir ??= "";
        file = (file ?? typeof(T).Name) + ".json";

        return Write(Path.Combine(dir, file), obj);
    }

    public static (string json, bool success) Write<T>(string path, T obj, bool forceExtension = true)
    {
        if (forceExtension && !path.EndsWith(".json"))
        {
            path += ".json";
        }

        return TextFileReadWriter.Write(path, JsonUtility.ToJson(obj));
    }
}