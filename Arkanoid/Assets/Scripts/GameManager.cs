using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    float score = 0;
    int lives = 3;
    int level = 1;

    int[] HighScoreList;
    List<GameObject> bricksList;
    [SerializeField] public float ballSpeed = 250f;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        HighScoreList = new int[5];
    }
    // Start is called before the first frame update
    void Start()
    {
        bricksList = new List<GameObject>();
        //NewGame(); 
        //GameObject.FindWithTag("LevelText").GetComponent<Text>().text = "LEVEL: " + this.level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        this.level = 1;
        
        LoadLevel();
    }

    public void NextLevel()
    {
        this.lives = 3;
        
        LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Level");
        level++;
    }

    public void IncreaseScore(float modifier)
    {
        this.score= (this.score + 10 + (modifier*this.score));
        GameObject.FindWithTag("ScoreText").GetComponent<Text>().text = "SCORE: " + this.score;
    }

    public void DecreaseLife()
    {
        
        if (lives > 0)
            this.lives--;
        else
        {
            NewGame();
        }
    }

    public void AddtoList(GameObject[] gameObjects)
    {
        this.bricksList = gameObjects.ToList();
    }

    public void RemoveFromList(GameObject gameObject)
    {
        this.bricksList.Remove(gameObject);
        
    }

    public int GetListCount()
    {
        return this.bricksList.Count;
    }

    
}
