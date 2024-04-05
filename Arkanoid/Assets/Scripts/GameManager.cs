using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int lives = 3;
    int level = 1;

    [SerializeField] public float ballSpeed = 250f;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
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
        Debug.Log("SCORE = " + score + "\nLIVES = " + lives + "\nLEVEL = " + level);
        LoadLevel();
    }

    public void NextLevel()
    {
        this.lives = 3;
        Debug.Log("SCORE = " + score + "\nLIVES = " + lives + "\nLEVEL = " + level);
        LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("Level");
        level++;
    }
}
