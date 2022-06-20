using System.Collections;
using System.Linq;
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
        SceneManager.sceneLoaded += initializeNewScene;
    }

    public void LoadScene(SceneIndex pScene)
    {
        if (_isLoading) return;

        StartCoroutine(load(pScene));
    }

    private IEnumerator load(SceneIndex pScene)
    {
        _isLoading = true;

        //Fade in the loading screen
        yield return StartCoroutine(fade(1, _fadeDuration));

        yield return PersistentMap.ActivateScene(pScene);
        _onSceneChange?.Invoke();

        //Fade out the loading screen
        yield return StartCoroutine(fade(0, _fadeDuration));

        _isLoading = false;
    }

    private IEnumerator fade(float pValue, float pDuration)
    {
        DOTween.To(() => _loadingScreen.alpha, x => _loadingScreen.alpha = x, pValue, pDuration);
        yield return new WaitForSeconds(pDuration);
    }

    private void initializeNewScene(Scene pScene, LoadSceneMode pMode)
    {
        SceneIndex sceneIndex = (SceneIndex)pScene.buildIndex;
        if (PersistentMap.sceneMaps.ContainsKey(sceneIndex)) return;

        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(pScene);


        GameObject[] rootObjects = pScene.GetRootGameObjects();
        GameObject newRoot = new GameObject();

        rootObjects.ToList().ForEach(x => x.transform.parent = newRoot.transform);

        PersistentMap newMap = newRoot.AddComponent<PersistentMap>();
        newMap.rootObject = newRoot;

        PersistentMap.sceneMaps.Add(sceneIndex, newMap);


        SceneManager.SetActiveScene(activeScene);
    }
}