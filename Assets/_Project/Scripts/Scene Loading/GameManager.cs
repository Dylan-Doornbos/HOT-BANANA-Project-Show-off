using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _loadingScreen;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private UnityEvent _onSceneChange;

    public static GameManager instance;

    private bool _isLoading;

    private void Awake()
    {
        instance = this;
    }

    public void LoadScene(SceneIndex pScene)
    {
        if(_isLoading) return;
        
         StartCoroutine(load(pScene));
    }

    private IEnumerator load(SceneIndex pScene)
    {
        _isLoading = true;
        
        //Fade in the loading screen
        yield return StartCoroutine(fade(1, _fadeDuration));

        _onSceneChange?.Invoke();

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

        //Fade out the loading screen
        yield return StartCoroutine(fade(0, _fadeDuration));

        _isLoading = false;
    }

    private IEnumerator fade(float pValue, float pDuration)
    {
        DOTween.To(() => _loadingScreen.alpha, x => _loadingScreen.alpha = x, pValue, pDuration);
        yield return new WaitForSeconds(pDuration);
    }
}