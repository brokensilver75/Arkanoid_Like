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
    [SerializeField] GameObject slowBall, pierceBall;
    bool bonus = false;
    //[SerializeField] GameManager gameManager;
    
    GameObject drop, gameManager;

    void Start()
    {
        
        gameManager = GameObject.Find("GameManager");
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
                BrickDeath();
                break;
        }
        
    }

    public void BrickDeath()
    {
        gameManager.GetComponent<GameManager>().IncreaseScore(modifier);
        DropStuff(UnityEngine.Random.Range(0, 3));
        gameManager.GetComponent<GameManager>().RemoveFromList(this.gameObject);
        Destroy(this.gameObject);
    }

    private void DropStuff(int chance)
    {
        switch (chance)
        {
            case 0: Instantiate(slowBall, transform.position, Quaternion.identity);
                    break;
            case 1: Instantiate(pierceBall, transform.position, Quaternion.identity);
                    break;
        }
        
    }

    IEnumerator Bonus()
    {
        bonus = true;
        modifier = 0.1f;
        yield return new WaitForSeconds(0.1f);
        modifier = 0;
        bonus = false;
    }


}
