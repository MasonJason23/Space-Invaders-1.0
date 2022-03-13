using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        string scene = "MainGame";
        StartCoroutine(Delay(scene));
    }

    public void LoadMainMenu()
    {
        string scene = "MainGame";
        StartCoroutine(Delay(scene));
    }
    
    IEnumerator Delay(string scene)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(scene);
    }
}
