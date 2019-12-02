# Unity_JsonFileReadWriter

``JsonFileReadWriter`` provides simple functions to de/serialize json from/to file.

## Import to Your Project

You can import this asset from UnityPackage.

- [JsonFileReadWriter.unitypackage](https://github.com/XJINE/Unity_JsonFileReadWriter/blob/master/JsonFileReadWriter.unitypackage)

### Dependencies

You have to import following assets to use this asset.

- [Unity_TextFileReadWriter](https://github.com/XJINE/Unity_TextFileReadWriter)

## How to Use

Following functions are sample.

``WriterJson~`` functions write the json of ``obj`` into ``.json`` file.
When the ``file`` set as ``null`` the file name gets ``T``.
And when the ``dir`` set as ``null``, the directory set as top.

```csharp
WriteJsonToStreamingAssets<T>(T obj, string dir = null, string file = null)
WriteJsonToFile<T>(T obj, string dir = null, string file = null)
ReadJsonFromStreamingAssets<T>(string dir = null, string file = null)
ReadJsonFromFile<T>(string dir = null, string file = null)
```

The args of ``ReadJson~`` works same as ``WriteJson~``.