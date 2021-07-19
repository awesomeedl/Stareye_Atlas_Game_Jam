using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        //SceneManager.LoadScene("StartMenu");
    }

    public void LoadLevelSelection()
    {
        //SceneManager.LoadScene("LevelSelection");
    }

    public void LoadGameOver()
    {
        //SceneManager.LoadScene("GameOver");
    }

    public void LoadLevel1()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
