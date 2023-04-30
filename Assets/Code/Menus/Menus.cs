using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject settingsMenu;
    public GameObject levelsSelectionMenu;

    private bool settingsOpen;
    private bool levelSelectionOpen;

    private void Start() {
        this.settingsOpen = false;
        levelSelectionOpen = false;
        this.settingsMenu.SetActive(this.settingsOpen);
        this.levelsSelectionMenu.SetActive(this.levelSelectionOpen);
    }

    public void PlayGame() {
        //SceneManager.LoadScene(1);

        LevelsSelectionMenu();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SettingsMenu() {
        this.settingsOpen = !this.settingsOpen;
        this.settingsMenu.SetActive(this.settingsOpen);
    }

    public void LevelsSelectionMenu()
    {
        this.levelSelectionOpen = !this.levelSelectionOpen;
        this.levelsSelectionMenu.SetActive(this.levelSelectionOpen);
    }
}
