using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static int levelCheckPoint = 1;
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
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(levelCheckPoint);
    }

    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
        levelCheckPoint = nextScene;
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Gameover");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        levelCheckPoint = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
