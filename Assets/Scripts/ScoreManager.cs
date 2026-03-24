using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int perfectHitScore = 100;
    [SerializeField] private int goodHitScore = 50;
    [SerializeField] private int missScore = 0;
    [SerializeField] private float perfectThreshold = 0.8f;

    private int score;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(float accuracy)
    {
        if (accuracy >= perfectThreshold)
        {
            score += perfectHitScore;
            Debug.Log("Perfect hit! +" + perfectHitScore);
        }
        else
        {
            score += goodHitScore;
            Debug.Log("Good hit! +" + goodHitScore);
        }

        scoreText.text = "Score: " + score;
    }


}