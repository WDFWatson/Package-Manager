using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int errors;
    public static ScoreManager instance;

    public ScoreDisplay scoreDisplay;

    private void Awake()
    {
        score = 0;
        errors = 0;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (scoreDisplay == null)
        {
            scoreDisplay = FindObjectOfType<ScoreDisplay>();
        }
    }

    public void Score(List<int> contents, bool isLegalChute)
    {
        BoxSpawner.instance.activeBoxes--;
        bool isLegal = true;
        foreach (int illegalItem in ItemManager.instance.illegalItems)
        {
            if (contents.Contains(illegalItem))
            {
                isLegal = false;
                break;
            }
        }

        if (isLegal == isLegalChute)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
    }

    void Correct()
    {
        score++;
        scoreDisplay.UpdateScore(score);
    }

    void Incorrect()
    {
        if (errors >= 3)
        {
            LoadManager.instance.LoadGameOver();
        }
        errors++;
        scoreDisplay.AddError();
    }
}
