using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void StartButton()
    {

        SceneManager.LoadScene("ROM Room");
    }
}
