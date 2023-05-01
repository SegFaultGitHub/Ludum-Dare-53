using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private GameObject gameOverMenu;
    private bool gameOverMenuOpen;

    [SerializeField] private GameObject previousLevelButton;
    [SerializeField] private GameObject nextLevelButton;

    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private ScoreManagement scoreManagement;

    [SerializeField] private List<GameObject> stars;


    // Start is called before the first frame update
    void Start()
    {
        gameOverMenuOpen = false;
        this.gameOverMenu.SetActive(this.gameOverMenuOpen);

        if (SceneManager.GetActiveScene().name == "Level01")
        {
            this.previousLevelButton.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level03")
        {
            this.nextLevelButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        this.gameOverMenuOpen = !this.gameOverMenuOpen;
        this.gameOverMenu.SetActive(this.gameOverMenuOpen);

        scoreText.text = scoreManagement.score.ToString();

        float step = (scoreManagement.maxScore - scoreManagement.minScore) / 4;
        float starUnlocked = Mathf.Clamp(Mathf.Ceil((scoreManagement.score - scoreManagement.minScore + 1) / step), 1, 5);

        for (int i = 0; i < starUnlocked; i++)
        {
            stars[i].SetActive(true);
        }

        Time.timeScale = gameOverMenuOpen ? 0 : 1;
    }

    public void BackMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadPreviousLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
