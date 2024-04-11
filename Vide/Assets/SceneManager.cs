using Oculus.Interaction.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;




public class SceneLoadManager : MonoBehaviour
{

    public static SceneLoadManager instance;
    [SerializeField] private SceneLoadController loader;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("INSTANCE ALREADY FOUND!!!");
            Destroy(this.gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        loader = GetComponent<SceneLoadController>();
        DontDestroyOnLoad(this);
    }

    public void LoadScene(string sceneName)
    {
        loader.Load(sceneName);
    }

    [ContextMenu("Test Loading")]
    public void LoadTestScene()
    {
        loader.LoadInstantly(1);
    }

    [ContextMenu("Load Main Menu")]
    public void LoadMainScene()
    {
        loader.LoadInstantly(0);
    }
}
