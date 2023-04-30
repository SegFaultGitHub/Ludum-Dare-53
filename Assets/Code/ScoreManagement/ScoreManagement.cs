using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour {

    [SerializeField] private int score;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    private void Start() {
        this.score = 0;
        this.UpdateScore();
    }

    // Update is called once per frame
    private void Update() { }

    public void AddScore(float scoreToAdd) {
        this.score = this.score + (int)scoreToAdd;

        this.UpdateScore();
    }

    private void UpdateScore() {
        this.scoreText.text = this.score.ToString();
    }
}
