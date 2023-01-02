using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeModule : MonoBehaviour
{
    private ScoreManager scoreManager;

    private Dictionary<Score, float> judgeTime;

    public LineManager line;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();

        line = GetComponent<LineManager>();

        judgeTime = new Dictionary<Score, float>()
        {
            { Score.Perfect, 0.04f },
            { Score.Great, 0.1f },
            { Score.Miss, 0.5f }
        };

    }

    public void touch()
    {
        NoteModule note = line.getJudgeNote();
        if (note == null) return;

        Score score = judgeNote(note);
        scoreManager.increaseScore(score);

        note.gameObject.SetActive(false);
    }

    private Score judgeNote(NoteModule note)
    {
        float diffTime = 
            Mathf.Abs(note.NoteTime - line.gameManager.GetTime());

        if (diffTime <= judgeTime[Score.Perfect]) return Score.Perfect;
        else if (diffTime <= judgeTime[Score.Great]) return Score.Great;
        else if (diffTime <= judgeTime[Score.Miss]) return Score.Miss;

        return Score.Miss;
    }
}
