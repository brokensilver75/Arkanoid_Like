using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed;
    GameObject gameManager;
    Vector3 initialBallPos;
    [SerializeField] Text scoreText;
    [SerializeField] Sprite normalBall, slowBall, pierceBall;
    Rigidbody2D ballRb;
    bool slowed = false, piercing = false;
    // Start is called before the first frame update
    void Start()
    {
        initialBallPos = transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        ballRb = GetComponent<Rigidbody2D>();
        ballRb.velocity = (new Vector2(0, gameManager.GetComponent<GameManager>().ballSpeed)) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MaintainVelocity(); 
        
        if (ballRb.velocity.y == 0)
            ballRb.velocity = new Vector2( 0 , gameManager.GetComponent<GameManager>().ballSpeed) * Time.deltaTime;

        if (gameManager.GetComponent<GameManager>().GetListCount() == 0)
        {
            transform.position = initialBallPos;
            ballRb.velocity = (new Vector2(0, gameManager.GetComponent<GameManager>().ballSpeed)) * Time.deltaTime;
        }
    }

    private void MaintainVelocity()
    {
        ballRb.velocity = (ballRb.velocity.normalized) * ballSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.GetComponent<Brick>().GetHit();
        }

        if (other.gameObject.CompareTag("DeathWall"))
        {
            gameManager.GetComponent<GameManager>().DecreaseLife();
        }
    }

    public void SlowDownBall()
    {
        if (!slowed)
            StartCoroutine(SlowMoBall());
    }

    public void PiercingBall()
    {
        if (!piercing)
            StartCoroutine(PierceBall());
    }

    IEnumerator SlowMoBall()
    {
        slowed = true;
        ballSpeed /= 5;
        GetComponent<SpriteRenderer>().sprite = slowBall;
        yield return new WaitForSeconds(5);
        slowed = false;
        GetComponent<SpriteRenderer>().sprite = normalBall;
        ballSpeed *= 5;
    }

    IEnumerator PierceBall()
    {
        piercing = true;
        GetComponent<SpriteRenderer>().sprite = pierceBall;
        yield return new WaitForSeconds(5);
        piercing = false;
        GetComponent<SpriteRenderer>().sprite = normalBall;
    }
}
