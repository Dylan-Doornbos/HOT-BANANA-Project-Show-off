using UnityEngine.SceneManagement;

public class SceneTransition
{
    public void ChangeScene(int pSceneIndex)
    {
        if (pSceneIndex < 0 || pSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            throw new System.Exception("Scene index does not exist in the Build Settings.");
        }

        SceneManager.LoadScene(pSceneIndex);
    }
}
