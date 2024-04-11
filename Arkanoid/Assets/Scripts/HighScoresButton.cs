using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text highScoretext;
    
    public void ShowScores()
    {
        highScoretext.text = PlayerPrefs.GetString("HighScores");
    }
}
