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
    Rigidbody2D ballRb;
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
        if (ballRb.velocity.y == 0)
            ballRb.velocity = new Vector2( 0 , gameManager.GetComponent<GameManager>().ballSpeed) * Time.deltaTime;

        if (gameManager.GetComponent<GameManager>().GetListCount() == 0)
        {
            transform.position = initialBallPos;
            ballRb.velocity = (new Vector2(0, gameManager.GetComponent<GameManager>().ballSpeed)) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.GetComponent<Brick>().GetHit();
        }

        /*if (other.gameObject.CompareTag("DeathWall"))
        {
            gameManager.GetComponent<GameManager>().DecreaseLife();
        }*/
    }
}
