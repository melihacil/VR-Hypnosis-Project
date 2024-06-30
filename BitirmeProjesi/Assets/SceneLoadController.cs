using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : MonoBehaviour
{
    private bool _loading = false;
    public Action<string> WhenLoadingScene = delegate { };
    public Action<string> WhenSceneLoaded = delegate { };
    private int _waitingCount = 0;

    public void Load(string sceneName)
    {
        if (_loading) return;
        _loading = true;
        // make sure we wait for all parties concerned to let us know they're ready to load
        _waitingCount = WhenLoadingScene.GetInvocationList().Length - 1;  // remove the count for the blank delegate
        if (_waitingCount == 0)
        {
            // if nobody else cares just set the preload to go directly to the loading of the scene
            HandleReadyToLoad(sceneName);
        }
        else
        {
            WhenLoadingScene.Invoke(sceneName);
        }
    }
    public void Load(int sceneIndex)
    {
        if (_loading) return;
        _loading = true;
        // make sure we wait for all parties concerned to let us know they're ready to load
        _waitingCount = WhenLoadingScene.GetInvocationList().Length - 1;  // remove the count for the blank delegate
        if (_waitingCount == 0)
        {
            // if nobody else cares just set the preload to go directly to the loading of the scene
            HandleReadyToLoad(sceneIndex);
        }
        else
        {
            WhenLoadingScene.Invoke(SceneManager.GetSceneAt(sceneIndex).name);
        }
    }

    public void LoadInstantly(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // this should be called after handling any pre-load tasks (e.g. fade to white) by anyone who regsistered with WhenLoadingScene in order for the loading to proceed
    public void HandleReadyToLoad(string sceneName)
    {
        _waitingCount--;
        if (_waitingCount <= 0)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
    }

    // this should be called after handling any pre-load tasks (e.g. fade to white) by anyone who regsistered with WhenLoadingScene in order for the loading to proceed
    public void HandleReadyToLoad(int sceneIndex)
    {
        _waitingCount--;
        if (_waitingCount <= 0)
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        WhenSceneLoaded.Invoke(sceneName);
    }


    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        WhenSceneLoaded.Invoke(SceneManager.GetSceneAt(sceneIndex).name);
    }
}