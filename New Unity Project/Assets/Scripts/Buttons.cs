using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Quit()
    {
        SceneLoader.instance.Quit();
    }

    public void Retry()
    {
        SceneLoader.instance.Retry();
    }

    public void LoadStart()
    {
        SceneLoader.instance.LoadLevel1();
    }

    public void LoadMenu()
    {
        SceneLoader.instance.LoadMenu();
    }
}
