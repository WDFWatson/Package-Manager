using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public LayoutGroup errors;
    public Image errorIcon;
    
    public void UpdateScore(int newScore)
    {
        text.text = newScore.ToString().PadLeft(3, '0');
    }

    public void AddError()
    {
        Instantiate(errorIcon, errors.transform);
    }
}
