# Unity_JsonFileReadWriter

``JsonFileReadWriter`` provides simple functions to de/serialize json from/to file.

## Dependencies

You have to import following assets to use this asset.

- [Unity_TextFileReadWriter](https://github.com/XJINE/Unity_TextFileReadWriter)

## How to Use

Following functions are sample.

``Write~`` functions write the json of ``obj`` into ``.json`` file.
``Read~`` functions read ``.json`` file into ``obj``.
When the ``file`` set as ``null`` the file name gets ``T``.
And when the ``dir`` set as ``null``, the directory set as top.

### Example

```csharp
WriteToStreamingAssets<T>(string dir, T obj)
Write<T>(string path, T obj)
ReadFromStreamingAssets<T>(string dir, string file)
ReadFromStreamingAssets<T>(string dir, string file, T obj)
Read<T>(string dir, string file)
```