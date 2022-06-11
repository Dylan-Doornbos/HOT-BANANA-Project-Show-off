using UnityEngine.SceneManagement;

public class SceneTransition
{
    public void ChangeScene(SceneIndex pScene)
    {
        int index = (int)pScene;
        
        if (index < 0 || (int)index >= SceneManager.sceneCountInBuildSettings)
        {
            throw new System.Exception("Scene index does not exist in the Build Settings.");
        }

        SceneManager.LoadScene(index);
    }
}
