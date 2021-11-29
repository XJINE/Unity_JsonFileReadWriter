using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleClass sampleClass;

    public string  directory         = "SampleDir";
    public KeyCode setRandomValueKey = KeyCode.S;
    public KeyCode readJsonKey       = KeyCode.R;
    public KeyCode writeJsonKey      = KeyCode.W;

    #endregion Field

    #region Method

    private void Start()
    {
        sampleClass.SetRandomValue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(setRandomValueKey))
        {
            sampleClass.SetRandomValue();
        }

        if (Input.GetKeyDown(writeJsonKey))
        {
            JsonFileReadWriter.WriteJsonToStreamingAssets(sampleClass, directory);
        }

        if (Input.GetKeyDown(readJsonKey))
        {
            JsonFileReadWriter.ReadJsonFromStreamingAssets(sampleClass, directory);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("[" + setRandomValueKey + "] Set Random Value.");
        GUILayout.Label("[" + readJsonKey       + "] Read Json.");
        GUILayout.Label("[" + writeJsonKey      + "] Write Json.");
    }

    #endregion Method
}