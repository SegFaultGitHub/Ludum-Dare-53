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

    public void LevelLoading(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
