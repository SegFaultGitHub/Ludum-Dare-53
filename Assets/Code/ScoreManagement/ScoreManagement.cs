using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour {

    [field: SerializeField] public int score { get; private set; }
    [field: SerializeField] public int minScore { get; private set; }
    [field: SerializeField] public int maxScore { get; private set; }
    

    public TMP_Text scoreText;

    // Start is called before the first frame update
    private void Start() {
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
