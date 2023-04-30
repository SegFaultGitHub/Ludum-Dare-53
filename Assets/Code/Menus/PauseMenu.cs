using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    private bool pauseMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuOpen = false;
        this.pauseMenu.SetActive(this.pauseMenuOpen);
    }

    // Update is called once per frame
    void Update()
    {
        this.GatherInputs();

        if(this.Input.toggleMenu)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        this.pauseMenuOpen = !this.pauseMenuOpen;
        this.pauseMenu.SetActive(this.pauseMenuOpen);

        Time.timeScale = pauseMenuOpen ? 0 : 1;
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    #region Input
    private InputActions InputActions;

    private class _Input
    {
        public bool toggleMenu;
    }
    private _Input Input = new();

    private void OnEnable()
    {
        this.InputActions = new InputActions();
        this.InputActions.Menus.Enable();
        this.Input = new _Input
        {
            toggleMenu = false
        };
    }

    private void OnDisable()
    {
        this.InputActions.Menus.Disable();
    }

    private void GatherInputs()
    {
        this.Input = new _Input
        {
            toggleMenu = this.InputActions.Menus.Pause.WasPerformedThisFrame()
        };
    }
    #endregion
}
