using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


// Data struct, büyük bir yapı olmadığı için class a gerek yok
public struct SequenceDataValues
{
    public float totalTime;
    public float totalGazeTime;
    public float totalExpectedGazeTime;
    public byte totalObjects;
    public byte totalGazedObjects;
    public byte levelIndex;
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
    public short lastActiveIndex = -1;
    public static   int num10 = 10;
    [SerializeField] private ScorePanel _mainMenuScorePanel;
    [SerializeField] private GameObject _startGameObject;
    [SerializeField] private GameObject[] _startInactiveObjects;
    [SerializeField] private PlayableDirector _startDirector;
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


    public void StartStairSequence()
    {
       _startGameObject.SetActive(true);
        foreach (var obj in _startInactiveObjects)
        {
            obj.SetActive(false);
        }
        _startDirector.Play();
    }

    public void SetSequenceData(short index, SequenceDataValues value)
    {
        _datas[index] = value;
        lastActiveIndex = index;
        Debug.Log("Sequence Ended");
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
        if (_datas.Length <= 0)
        {
            return;
        }

        if (scene.buildIndex.Equals(0))
        {
            //_mainMenuScorePanel = GameObject.FindGameObjectWithTag("ScorePanel").GetComponent<ScorePanel>();
            _mainMenuScorePanel = GameObject.Find("Menu Panel").GetComponent<MenuController>().panelInfo;
            _mainMenuScorePanel.UpdateScoreTexts(ReturnTexts());
            Debug.Log(ReturnTexts());
            //Debug.Log("Scene loaded: " + scene.name + " Loaded gameobject" + _mainMenuScorePanel.gameObject);

        }
    }

    private string[] ReturnTexts()
    {
        var data = _datas[lastActiveIndex];

        return new string[] { data.totalTime.ToString(), 
            data.totalGazeTime.ToString(), 
            data.totalExpectedGazeTime.ToString(), 
            data.totalObjects.ToString(), 
            data.totalGazedObjects.ToString(),
            data.levelIndex.ToString()
        };
    }
}
