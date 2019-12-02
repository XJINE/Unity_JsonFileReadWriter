using UnityEngine;

public class Sample : MonoBehaviour
{
    #region Field

    public SampleClass sampleClass;

    public KeyCode SetRandomValueKey = KeyCode.S;
    public KeyCode ReadJsonKey       = KeyCode.R;
    public KeyCode WriteJsonKey      = KeyCode.W;

    #endregion Field

    #region Method

    protected virtual void Start()
    {
        this.sampleClass = new SampleClass();
        this.sampleClass.SetRandomValue();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(this.SetRandomValueKey))
        {
            this.sampleClass.SetRandomValue();
        }

        if (Input.GetKeyDown(this.WriteJsonKey))
        {
            if (JsonFileReadWriter.WriteJsonToStreamingAssets(this.sampleClass, "JsonSample", "SampleDir"))
            {
                Debug.Log("Success : Write Json.");
            }
            else
            {
                Debug.Log("Failure : Write Json.");
            }
        }

        if (Input.GetKeyDown(this.ReadJsonKey))
        {
            JsonFileReadWriter.ReadJsonFromStreamingAssets(this.sampleClass, "JsonSample", "SampleDir");
        }
    }

    protected virtual void OnGUI()
    {
        GUILayout.Label("[" + this.SetRandomValueKey + "] Set Random Value.");
        GUILayout.Label("[" + this.ReadJsonKey       + "] Read Json.");
        GUILayout.Label("[" + this.WriteJsonKey      + "] Write Json.");
    }

    #endregion Method
}