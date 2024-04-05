using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed;
    [SerializeField] GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, gameManager.GetComponent<GameManager>().ballSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            other.gameObject.GetComponent<Brick>().GetHit();
        }
    }
}
