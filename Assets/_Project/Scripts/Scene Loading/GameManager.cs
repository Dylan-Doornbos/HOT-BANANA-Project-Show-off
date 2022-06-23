using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action onSceneChangeBegin;
    public static event Action onSceneChangeEnd;

    public static GameManager instance;

    private bool _isLoading;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void LoadScene(SceneIndex pScene, bool pStartFaded = false)
    {
        if(_isLoading) return;
        
         StartCoroutine(load(pScene, pStartFaded));
    }

    private IEnumerator load(SceneIndex pScene, bool pStartFaded)
    {
        _isLoading = true;
        
        onSceneChangeBegin?.Invoke();
        
        //Fade in the loading screen
        yield return StartCoroutine(Player.instance.FadeIn());

        Player.instance.SetLoadingTextVisibility(true);


        List<AsyncOperation> operations = new List<AsyncOperation>();

        //Load the new scene
        operations.Add(SceneManager.LoadSceneAsync((int)pScene));

        //Wait for loading and unloading to be finished
        foreach (var operation in operations)
        {
            while (!operation.isDone)
            {
                yield return null;
            }
        }
        
        onSceneChangeEnd?.Invoke();

        _isLoading = false;
    }
}