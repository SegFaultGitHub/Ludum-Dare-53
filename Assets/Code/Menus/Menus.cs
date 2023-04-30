using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject settingsMenu;
    private bool settingsOpen;

    private void Start() {
        this.settingsOpen = false;
        this.settingsMenu.SetActive(this.settingsOpen);
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SettingsMenu() {
        this.settingsOpen = !this.settingsOpen;
        this.settingsMenu.SetActive(this.settingsOpen);
    }
}
