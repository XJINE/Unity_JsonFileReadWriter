using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

// NOTE:
// Unity.JsonUtility does not support Jagged, Dictionary, Property.
// Unity.JsonUtility does not consider the IgnoreDataMember attribute.

[System.Serializable]
public class SampleClass
{
    [System.Serializable]
    public struct Struct
    {
        public int intValue;
    }

    [System.Serializable]
    public class Class
    {
        public int intValue;
    }

    #region Field

    public        int intValue;
    private       int intPrivate;
    public static int intStatic;

    [SerializeField]   private int intPrivateSerialize;
    [IgnoreDataMember] public  int intIgnore;

    public int[]                intArray;
    public int[][]              intJagged;
    public List<int>            intList;
    public Dictionary<int, int> intDictionary;

    public float  floatValue;
    public bool   boolValue;
    public char   charValue;
    public string stringValue;

    public Vector2    vector2Value;
    public Vector3    vector3Value;
    public Vector4    vector4Value;
    public Quaternion quaternionValue;
    public Matrix4x4  matrixValue;
    public Transform  transformValue;

    public CameraType enumValue;
    public Struct     structValue;
    public Class      classValue;

    public Struct[]    structArray;
    public List<Class> classList;

    public int IntProperty { get; set; }

    #endregion Field

    #region Method

    public void SetRandomValue()
    {
        this.intValue            = Random.Range(1, 10);
        this.intPrivate          = Random.Range(1, 10);
             intStatic           = Random.Range(1, 10);
        this.intPrivateSerialize = Random.Range(1, 10);
        this.intIgnore           = Random.Range(1, 10);
        this.IntProperty         = Random.Range(1, 10);

        this.intArray = new int[Random.Range(1, 5)];
        for (int i = 0; i < this.intArray.Length; i++)
        {
            this.intArray[i] = Random.Range(1, 10);
        }

        this.intJagged = new int[Random.Range(1, 5)][];
        for (int i = 0; i < this.intJagged.Length; i++)
        {
            this.intJagged[i] = new int[i];
            for (int j = 0; j < this.intJagged[i].Length; j++)
            {
                this.intJagged[i][j] = Random.Range(1, 10);
            }
        }

        this.intList = new List<int>();
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            this.intList.Add(Random.Range(1, 10));
        }

        this.intDictionary = new Dictionary<int, int>();
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            this.intDictionary.Add(i, Random.Range(1, 10));
        }

        this.floatValue  = Random.Range(1, 10.0f);
        this.boolValue   = Random.Range(0, 2) == 0 ? true : false;
        this.charValue   = Random.Range(1, 10).ToString()[0];
        this.stringValue = Random.Range(1, 10).ToString();

        this.vector2Value = new Vector2()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
        } ;

        this.vector3Value = new Vector3()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
        };

        this.vector4Value = new Vector4()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
            w = Random.Range(1, 10f),
        };

        this.quaternionValue = new Quaternion()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
            w = Random.Range(1, 10f)
        };

        this.matrixValue = new Matrix4x4()
        {
            m00 = Random.Range(1, 10f),
            m01 = Random.Range(1, 10f),
            m02 = Random.Range(1, 10f),
            m03 = Random.Range(1, 10f),
            m10 = Random.Range(1, 10f),
            m11 = Random.Range(1, 10f),
            m12 = Random.Range(1, 10f),
            m13 = Random.Range(1, 10f),
            m20 = Random.Range(1, 10f),
            m21 = Random.Range(1, 10f),
            m22 = Random.Range(1, 10f),
            m23 = Random.Range(1, 10f),
            m30 = Random.Range(1, 10f),
            m31 = Random.Range(1, 10f),
            m32 = Random.Range(1, 10f),
            m33 = Random.Range(1, 10f),
        };

        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

        if (gameObjects != null && gameObjects.Length != 0)
        {
            this.transformValue = gameObjects[Random.Range(0, gameObjects.Length)].transform;
        }

        this.enumValue = (CameraType)Random.Range(0, System.Enum.GetValues(typeof(CameraType)).Length);

        this.structValue = new Struct() { intValue = Random.Range(1, 10) };

        this.classValue = new Class() { intValue = Random.Range(1, 10) };

        this.structArray = new Struct[Random.Range(1, 5)];

        for (int i = 0; i < this.structArray.Length; i++)
        {
            this.structArray[i] = new Struct() { intValue = Random.Range(1, 10) };
        }

        this.classList = new List<Class>();

        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            this.classList.Add(new Class() { intValue = Random.Range(1, 10) });
        };
    }

    #endregion Method
}