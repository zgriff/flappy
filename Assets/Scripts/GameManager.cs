using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public void SceneLoad(string scene) 
    {
        Debug.Log(scene);
        SceneManager.LoadScene(scene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
    