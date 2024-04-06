using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick: MonoBehaviour
{
    int brickLives;
    float modifier = 0;
    [SerializeField] Sprite brick1, brick2, brick3;
    
    GameObject drop, gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        brickLives = Random.Range(0,4);
        switch(brickLives)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = brick1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = brick2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = brick3;
                break;
            case 0:
                Destroy(this.gameObject);
                gameManager.GetComponent<GameManager>().RemoveFromList(this.gameObject);
                break;
        }
    }
    public Brick(int brickLives)//, GameObject drop)
    {
        this.brickLives = brickLives;
        //this.drop = drop;
    }

    public void GetHit()
    {
        brickLives--;
        switch(brickLives)
        {
             case 1:
                this.GetComponent<SpriteRenderer>().sprite = brick1;
                 break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = brick2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = brick3;
                break;
            default:
                Destroy(this.gameObject);
                gameManager.GetComponent<GameManager>().IncreaseScore(modifier);
                gameManager.GetComponent<GameManager>().RemoveFromList(this.gameObject);
                break;
        }
        
    }

    public int GetBricklives()
    {
        return brickLives;
    }


}
