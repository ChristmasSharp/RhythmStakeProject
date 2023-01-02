using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public enum Score
{
    Perfect = 0,
    Great,
    Miss,
    Count
}

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreUI;
    
    private Dictionary<Score, TextMeshProUGUI> scoreText;
    private Dictionary<Score, string> scoreInitText;
    private Dictionary<Score, int> scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUI = GameObject.FindWithTag("ScoreBoard");

        scoreText = new Dictionary<Score, TextMeshProUGUI>()
        {
            {Score.Perfect, ScoreUI.transform.Find("PerfectScore").GetComponent<TextMeshProUGUI>()},
            {Score.Great, ScoreUI.transform.Find("GreatScore").GetComponent<TextMeshProUGUI>()},
            {Score.Miss, ScoreUI.transform.Find("MissScore").GetComponent<TextMeshProUGUI>()}
        };

        scoreInitText = new Dictionary<Score, string>()
        {
            {Score.Perfect, "Perfect: "},
            {Score.Great, "Great: "},
            {Score.Miss, "Miss: "}
        };

        scoreBoard = new Dictionary<Score, int>()
        {
            {Score.Perfect, 0},
            {Score.Great, 0},
            {Score.Miss, 0}
        };

        for (Score score = 0; score < Score.Count; score++)
        {
            scoreText[score].text =
                    scoreInitText[score] + scoreBoard[score].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(Score score)
    {
        scoreText[score].text = 
        scoreInitText[score] + (++scoreBoard[score]).ToString();
    }
}
