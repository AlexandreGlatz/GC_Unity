using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public LoadingScreen loadingScreen;
    public void GameStart()
    {
        loadingScreen.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
