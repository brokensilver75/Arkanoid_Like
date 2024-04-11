using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public void DeleteHighScores()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("HighScores", "0 0 0 0 0");
        PlayerPrefs.Save();
    }
}
