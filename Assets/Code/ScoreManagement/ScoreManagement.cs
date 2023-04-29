using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{

    [SerializeField] private int score;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        var scoreToAdd = 100f;
        score = score + (int) scoreToAdd;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

}
