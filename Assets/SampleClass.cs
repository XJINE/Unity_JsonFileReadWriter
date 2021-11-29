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
        intValue            = Random.Range(1, 10);
        intPrivate          = Random.Range(1, 10);
        intStatic           = Random.Range(1, 10);
        intPrivateSerialize = Random.Range(1, 10);
        intIgnore           = Random.Range(1, 10);
        IntProperty         = Random.Range(1, 10);

        intArray = new int[Random.Range(1, 5)];
        for (var i = 0; i < intArray.Length; i++)
        {
            intArray[i] = Random.Range(1, 10);
        }

        intJagged = new int[Random.Range(1, 5)][];
        for (var i = 0; i < intJagged.Length; i++)
        {
            intJagged[i] = new int[i];
            for (var j = 0; j < intJagged[i].Length; j++)
            {
                intJagged[i][j] = Random.Range(1, 10);
            }
        }

        intList = new List<int>();
        for (var i = 0; i < Random.Range(1, 5); i++)
        {
            intList.Add(Random.Range(1, 10));
        }

        intDictionary = new Dictionary<int, int>();
        for (var i = 0; i < Random.Range(1, 5); i++)
        {
            intDictionary.Add(i, Random.Range(1, 10));
        }

        floatValue  = Random.Range(1, 10.0f);
        boolValue   = Random.Range(0, 2) == 0 ? true : false;
        charValue   = Random.Range(1, 10).ToString()[0];
        stringValue = Random.Range(1, 10).ToString();

        vector2Value = new Vector2()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
        } ;

        vector3Value = new Vector3()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
        };

        vector4Value = new Vector4()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
            w = Random.Range(1, 10f),
        };

        quaternionValue = new Quaternion()
        {
            x = Random.Range(1, 10f),
            y = Random.Range(1, 10f),
            z = Random.Range(1, 10f),
            w = Random.Range(1, 10f)
        };

        matrixValue = new Matrix4x4()
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

        var gameObjects = Object.FindObjectsOfType<GameObject>();

        if (gameObjects != null && gameObjects.Length != 0)
        {
            transformValue = gameObjects[Random.Range(0, gameObjects.Length)].transform;
        }

        enumValue = (CameraType)Random.Range(0, System.Enum.GetValues(typeof(CameraType)).Length);

        structValue = new Struct() { intValue = Random.Range(1, 10) };

        classValue = new Class() { intValue = Random.Range(1, 10) };

        structArray = new Struct[Random.Range(1, 5)];

        for (var i = 0; i < structArray.Length; i++)
        {
            structArray[i] = new Struct() { intValue = Random.Range(1, 10) };
        }

        classList = new List<Class>();

        for (var i = 0; i < Random.Range(1, 5); i++)
        {
            classList.Add(new Class() { intValue = Random.Range(1, 10) });
        };
    }

    #endregion Method
}