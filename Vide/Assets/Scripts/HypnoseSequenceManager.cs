using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


// Data struct, büyük bir yapı olmadığı için class a gerek yok
public struct SequenceDataValues
{
    public float totalTime;
    public float totalGazeTime;
    public float totalExpectedGazeTime;
    public byte totalObjects;
    public byte totalGazedObjects;

    public readonly float GetGazeRatio()
    {
        return (totalGazeTime / totalExpectedGazeTime);
    }

    public readonly float GetGazeObjectRatio()
    {
        return (totalGazedObjects / totalObjects);
    }
}


public class HypnoseSequenceManager : MonoBehaviour
{
    public static HypnoseSequenceManager instance;

    private SequenceDataValues[] _datas;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Another instance is found !" + instance.gameObject);
            Destroy(this);
        }
        instance = this;
        _datas = new SequenceDataValues[3];
        DontDestroyOnLoad(this);
    }


    public void SetSequenceData(short index, SequenceDataValues value)
    {
        _datas[index] = value;
    }

    public SequenceDataValues GetSequenceData(byte index)
    {
        return _datas[index];
    }

}
