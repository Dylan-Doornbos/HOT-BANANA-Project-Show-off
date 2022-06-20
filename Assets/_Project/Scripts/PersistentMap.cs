using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMap : MonoBehaviour
{
    public static Dictionary<SceneIndex, PersistentMap> sceneMaps = new Dictionary<SceneIndex, PersistentMap>();

    public GameObject rootObject;

    public static IEnumerator ActivateScene(SceneIndex pScene)
    {
        //Deactivate the old scene scene
        Scene oldScene = SceneManager.GetActiveScene();
        if (sceneMaps.TryGetValue((SceneIndex)oldScene.buildIndex, out PersistentMap oldMap))
        {
            oldMap.rootObject.SetActive(false);
        }

        //Load/enable the new scene
        if (sceneMaps.TryGetValue(pScene, out PersistentMap map))
        {
            map.rootObject.SetActive(true);
        }
        else
        {
            yield return loadNewScene(pScene);
        }
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)pScene));
    }

    private static IEnumerator loadNewScene(SceneIndex pScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)pScene, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    private void OnDestroy()
    {
        Debug.Log("test");
    }
}