using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }

    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }

    //}

    public void SceneLoad(string scene) 
    {
        SceneManager.LoadScene(scene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
    