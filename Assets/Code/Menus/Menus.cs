using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject creditsMenu;
    public GameObject levelsSelectionMenu;

    private bool creditsOpen;
    private bool levelSelectionOpen;

    private void Start() {
        this.creditsOpen = false;
        levelSelectionOpen = false;
        this.creditsMenu.SetActive(this.creditsOpen);
        this.levelsSelectionMenu.SetActive(this.levelSelectionOpen);
    }

    public void PlayGame() {
        LevelsSelectionMenu();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void CreditsMenu() {
        this.creditsOpen = !this.creditsOpen;
        this.creditsMenu.SetActive(this.creditsOpen);
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
