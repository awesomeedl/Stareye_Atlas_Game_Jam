using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject credits;
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

    public void ToggleCredits()
    {
        credits.SetActive(!credits.activeInHierarchy);
    }
}
