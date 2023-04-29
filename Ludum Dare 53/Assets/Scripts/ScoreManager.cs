using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Score(List<int> contents, bool isLegalChute)
    {
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
        Debug.Log("Correct");
    }

    void Incorrect()
    {
        Debug.Log("Incorrect");
    }
}
