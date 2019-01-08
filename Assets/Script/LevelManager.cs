using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void SceneChange(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
