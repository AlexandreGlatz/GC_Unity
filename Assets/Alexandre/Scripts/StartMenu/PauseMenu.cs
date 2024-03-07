using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public LoadingScreen loadingScreen;
    private bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isOpened) {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }
    public void OpenMenu()
    {
        isOpened = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        isOpened = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToFarm()
    {
        isOpened = false;
        menu.SetActive(false);
        Time.timeScale = 1;
        loadingScreen.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
    
