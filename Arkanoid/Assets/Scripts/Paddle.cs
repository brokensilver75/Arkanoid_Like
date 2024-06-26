using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Vector3 paddlePos, contactPoint;
    GameObject gameManager;
    [SerializeField] float paddleSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        paddlePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
        if (gameManager.GetComponent<GameManager>().GetListCount() == 0)
        {
            transform.position = paddlePos;
        }
    }

    void MovePaddle()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -7.6)
                transform.position += -(new Vector3(paddleSpeed, 0, 0) * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 7.6)
                transform.position += (new Vector3(paddleSpeed, 0, 0) * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.CompareTag("Ball"))
        {
               contactPoint = other.contacts[0].point;

               if (contactPoint.x < paddlePos.x)
                other.gameObject.GetComponent<Rigidbody2D>().velocity += (new Vector2(-gameManager.GetComponent<GameManager>().ballSpeed, gameManager.GetComponent<GameManager>().ballSpeed)) * Time.deltaTime;

               else
                other.gameObject.GetComponent<Rigidbody2D>().velocity += (new Vector2(gameManager.GetComponent<GameManager>().ballSpeed, gameManager.GetComponent<GameManager>().ballSpeed)) * Time.deltaTime;
        }
    }
}
