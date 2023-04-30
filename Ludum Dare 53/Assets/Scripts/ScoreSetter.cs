using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSetter : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
        text.text = LoadManager.instance.score.ToString();
    }

}
