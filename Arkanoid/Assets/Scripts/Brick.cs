using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick: MonoBehaviour
{
    int brickLives;
    [SerializeField] Sprite brick1, brick2, brick3;
    GameObject drop;

    void Start()
    {
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
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<BoxCollider2D>().enabled = false;
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
                break;
        }
        
    }

    public int GetBricklives()
    {
        return brickLives;
    }


}
