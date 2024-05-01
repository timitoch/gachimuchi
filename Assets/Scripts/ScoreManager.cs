using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;

    public static float score;
    int highScore;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        highScore = (int)score;
        ScoreText.text = "" + highScore.ToString();

        if (PlayerPrefs.GetInt("score") <= highScore)
        {
            PlayerPrefs.SetInt("score", highScore);
        }
        HighScoreText.text = "" + PlayerPrefs.GetInt("score").ToString();
    }
}
