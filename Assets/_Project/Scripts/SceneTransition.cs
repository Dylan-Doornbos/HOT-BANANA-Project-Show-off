using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void ChangeScene(int pSceneIndex)
    {
        SceneManager.LoadScene(pSceneIndex);
    }
}
