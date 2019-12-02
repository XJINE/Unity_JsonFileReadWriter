using UnityEngine;
using static TextFileReadWriter;

public static class JsonFileReadWriter
{
    public static bool WriteJsonToStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        return WriteToStreamingAssets(ToJsonFilePath(dir, file ?? obj.GetType().ToString()), JsonUtility.ToJson(obj));
    }

    public static bool WriteJsonToFile<T>(T obj, string dir = null, string file = null)
    {
        return WriteToFile(ToJsonFilePath(dir, file ?? obj.GetType().ToString()), JsonUtility.ToJson(obj));
    }

    public static T ReadJsonFromStreamingAssets<T>(string dir = null, string file = null)
    {
        string json = ReadFromStreamingAssets(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        return json == null ? default : JsonUtility.FromJson<T>(json);
    }

    public static void ReadJsonFromStreamingAssets<T>(T obj, string dir = null, string file = null)
    {
        string json = ReadFromStreamingAssets(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (json != null)
        {
            JsonUtility.FromJsonOverwrite(json, obj);
        }
    }

    public static T ReadJsonFromFile<T>(string dir = null, string file = null)
    {
        string json = ReadFromFile(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        return json == null ? default : JsonUtility.FromJson<T>(json);
    }

    public static void ReadJsonFromFile<T>(T obj, string dir = null, string file = null)
    {
        string json = ReadFromFile(ToJsonFilePath(dir, file ?? typeof(T).ToString()));

        if (json != null)
        {
            JsonUtility.FromJsonOverwrite(json, obj);
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