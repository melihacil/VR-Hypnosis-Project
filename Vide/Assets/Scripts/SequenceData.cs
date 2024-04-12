using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class SequenceData : MonoBehaviour
{
    public float totalTime;
    public float totalGazeTime;
    public float totalExpectedGazeTime;
    public byte totalObjects; // 256 obje max
    public byte totalGazedObjects;
    public byte index; // sahne degeri

    public SequenceDataValues dataVal;

    public static SequenceData instance;


    [SerializeField] private PlayableDirector m_timeLine;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Another instance is found !" + instance.gameObject);
            Destroy(this);
        }
        instance = this; 

        if (m_timeLine != null)
        {
            totalTime = (float)m_timeLine.duration;
            Debug.Log(totalTime);
        }
    }

    public void AddSequenceObject(float duration, float gazedDuration, bool isGazed)
    {
        totalGazedObjects += isGazed ? (byte)1 : (byte)0;
        totalObjects++;
        totalExpectedGazeTime += duration;
        totalGazeTime += gazedDuration;
    }


    public void SequenceEnd()
    {
        SetSeqData();
        HypnoseSequenceManager.instance.SetSequenceData(index,dataVal);
    }
    private void SetSeqData()
    {
        dataVal.totalTime = this.totalTime;
        dataVal.totalGazeTime = this.totalGazeTime;
        dataVal.totalObjects = this.totalObjects;
        dataVal.totalGazedObjects = this.totalGazedObjects;
        dataVal.totalExpectedGazeTime = this.totalExpectedGazeTime;
        dataVal.levelIndex = this.index;
    }

}
