using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleNameSpace.SampleClass sampleClass;

    public string  directory         = "SampleDir";
    public KeyCode setRandomValueKey = KeyCode.S;
    public KeyCode readJsonKey       = KeyCode.R;
    public KeyCode writeJsonKey      = KeyCode.W;
    public bool    fullNameMode      = true;

    #endregion Field

    #region Method

    private void Start()
    {
        sampleClass.SetRandomValue();
    }

    private void Update()
    {
        JsonFileReadWriter.FullNameMode = fullNameMode;

        if (Input.GetKeyDown(setRandomValueKey))
        {
            sampleClass.SetRandomValue();
        }

        if (Input.GetKeyDown(writeJsonKey))
        {
            JsonFileReadWriter.WriteToStreamingAssets(directory, sampleClass);
        }

        if (Input.GetKeyDown(readJsonKey))
        {
            JsonFileReadWriter.ReadFromStreamingAssets(directory, sampleClass);
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