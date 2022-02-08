# Unity_JsonFileReadWriter

``JsonFileReadWriter`` provides simple functions to de/serialize json from/to file.

## Dependencies

You have to import following assets to use this asset.

- [Unity_TextFileReadWriter](https://github.com/XJINE/Unity_TextFileReadWriter)

## How to Use

Following functions are included.

```csharp
(T data, bool success) ReadFromAssets<T>(string dir = null, string file = null)
(T data, bool success) ReadFromStreamingAssets<T>(string dir = null, string file = null)
(T data, bool success) Read<T>(string dir = null, string file = null)
(T data, bool success) Read<T>(string path, bool forceExtension = true)

void ReadFromAssets<T>(T obj)
void ReadFromAssets<T>(string dir, T obj)
void ReadFromAssets<T>(string dir, string file, T obj)

void ReadFromStreamingAssets<T>(T obj)
void ReadFromStreamingAssets<T>(string dir, T obj)
void ReadFromStreamingAssets<T>(string dir, string file, T obj)

void Read<T>(string dir, string file, T obj)
void Read<T>(string path, T obj, bool forceExtension = true)

(string json, bool success) WriteToAssets<T>(T obj)
(string json, bool success) WriteToAssets<T>(string dir, T obj)
(string json, bool success) WriteToAssets<T>(string dir, string file, T obj)

(string json, bool success) WriteToStreamingAssets<T>(T obj)
(string json, bool success) WriteToStreamingAssets<T>(string dir, T obj)
(string json, bool success) WriteToStreamingAssets<T>(string dir, string file, T obj)

(string json, bool success) Write<T>(string dir, string file, T obj)
(string json, bool success) Write<T>(string path, T obj, bool forceExtension = true)
```