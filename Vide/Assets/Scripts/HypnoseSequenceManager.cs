using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


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


    [SerializeField] private ScorePanel _mainMenuScorePanel;

    private SequenceDataValues[] _datas;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Another instance is found !" + instance.gameObject);
            Destroy(this.gameObject);
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
    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Your code to execute after scene loading goes here

        if (scene.buildIndex.Equals(0))
        {

            //_mainMenuScorePanel = GameObject.FindGameObjectWithTag("ScorePanel").GetComponent<ScorePanel>();
            _mainMenuScorePanel = GameObject.Find("Menu Panel").GetComponent<MenuController>().panelInfo;

            Debug.Log("Scene loaded: " + scene.name + " Loaded gameobject" + _mainMenuScorePanel.gameObject);

        }
    }
}
