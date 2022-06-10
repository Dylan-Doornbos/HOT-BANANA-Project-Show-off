using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    
    public static GameManager instance;
    
    const SceneIndex _persistentScene = SceneIndex.CITY;
    private SceneIndex _activeScene = SceneIndex.MANAGER;
    private Coroutine _sceneChangeCoroutine = null;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

        LoadScene(SceneIndex.TITLE_SCREEN);
        SceneManager.LoadSceneAsync((int)SceneIndex.CITY);
    }

    public void LoadScene(SceneIndex pScene)
    {
        //Don't load if we're already loading or if we're trying to load the already active scene
        if(_sceneChangeCoroutine != null || pScene == _activeScene) return;

        _sceneChangeCoroutine = StartCoroutine(loadScene(pScene));
    }

    private IEnumerator loadScene(SceneIndex pScene)
    {
        _loadingScreen.SetActive(true);

        //Unload current scene
        if (_activeScene == _persistentScene)
        {
            
        }
        else
        {
            
        }
        
        //Load new scene
    }
}