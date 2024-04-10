using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Brick: MonoBehaviour
{
    int brickLives;
    float modifier = 0;
    [SerializeField] Sprite brick1, brick2, brick3;
    [SerializeField] GameObject slowBall;
    
    GameObject drop, gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        brickLives = UnityEngine.Random.Range(0,4);
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
                Instantiate(slowBall, transform.position, Quaternion.identity);
                gameManager.GetComponent<GameManager>().RemoveFromList(this.gameObject);

                break;
        }
        
    }

    public int GetBricklives()
    {
        return brickLives;
    }


}
