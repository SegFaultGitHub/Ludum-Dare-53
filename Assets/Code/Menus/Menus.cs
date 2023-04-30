using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    private bool settingsOpen;

    public GameObject settingsMenu;

    private void Start()
    {
        settingsOpen = false;
        settingsMenu.SetActive(settingsOpen);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        settingsOpen = !settingsOpen;
        settingsMenu.SetActive(settingsOpen);
    }
}
