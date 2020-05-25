using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleClass sampleClass;

    public string directory = "SampleDir";

    public KeyCode SetRandomValueKey = KeyCode.S;
    public KeyCode ReadJsonKey       = KeyCode.R;
    public KeyCode WriteJsonKey      = KeyCode.W;

    #endregion Field

    #region Method

    void Start()
    {
        this.sampleClass = new SampleClass();
        this.sampleClass.SetRandomValue();
    }

     void Update()
    {
        if (Input.GetKeyDown(this.SetRandomValueKey))
        {
            this.sampleClass.SetRandomValue();
        }

        if (Input.GetKeyDown(this.WriteJsonKey))
        {
            JsonFileReadWriter.WriteJsonToStreamingAssets(this.sampleClass, this.directory);
        }

        if (Input.GetKeyDown(this.ReadJsonKey))
        {
            JsonFileReadWriter.ReadJsonFromStreamingAssets(this.sampleClass, this.directory);
        }
    }

    void OnGUI()
    {
        GUILayout.Label("[" + this.SetRandomValueKey + "] Set Random Value.");
        GUILayout.Label("[" + this.ReadJsonKey       + "] Read Json.");
        GUILayout.Label("[" + this.WriteJsonKey      + "] Write Json.");
    }

    #endregion Method
}