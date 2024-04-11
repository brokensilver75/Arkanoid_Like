using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.UIElements;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    float score;
    static int lives = 3;
    int level = 1;
    int temp;

    int[] HighScoreList;
    List<GameObject> bricksList;
    [SerializeField] public float ballSpeed;

    string highScoreString;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        HighScoreList = new int[5];
    }
    // Start is called before the first frame update
    void Start()
    {
        if (lives == 0)
            lives = 3;
        
        NewGame();
        bricksList = new List<GameObject>();
       
        string[] ScoreList = PlayerPrefs.GetString("HighScores").Split(' ');
        HighScoreList = Array.ConvertAll(PlayerPrefs.GetString("HighScores", "0 0 0 0 0").Split(' '), int.Parse);
    }
    public void NewGame()
    {
        score = 0;
        lives = 3;
    }

    public void SetHighScores(float points)
    {
        for (int i = 0; i < 5; i++)
        {
            if (points > HighScoreList[i])
            {
                Debug.Log(score);
                temp = (int)points;
                points = HighScoreList[i];
                HighScoreList[i] = temp;
            }
        }

        highScoreString = "";
        for (int i = 0; i < 5; i++)
        {
            if (i < 4)
                highScoreString += HighScoreList[i].ToString() + " ";
            else
                highScoreString += HighScoreList[i].ToString();
        }

        PlayerPrefs.SetString("HighScores", highScoreString);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        lives = 3;
        LoadLevel();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
        level++;
    }

    public void IncreaseScore()
    {
        score += 10;
        GameObject.FindWithTag("ScoreText").GetComponent<Text>().text = "SCORE: " + score;
    }

    public void DecreaseLife()
    {
        Debug.Log(lives);
        if (lives > 0)
            lives--;
        else
        {
            SetHighScores(score);
            NewGame();
            NextLevel();            
            SceneManager.LoadScene("Global");
        }
    }

    public void AddtoList(GameObject[] gameObjects)
    {
        bricksList = gameObjects.ToList();
    }

    public void RemoveFromList(GameObject gameObject)
    {
        bricksList.Remove(gameObject);
        
    }

    public int GetListCount()
    {
        return bricksList.Count;
    }

    public float GetScore()
    {
        if (lives == 0)
        {
            Debug.Log(score);
            return score;
        }

        else
        {
            return 0;
        }
    }
    
}
