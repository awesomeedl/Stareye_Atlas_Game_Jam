using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Quit()
    {
        SceneLoader.instance.Quit();
    }

    public void Start()
    {
        SceneLoader.instance.LoadLevel1();
    }

    public void LoadMenu()
    {
        SceneLoader.instance.LoadMenu();
    }
}
