using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PierceBall : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        GetComponent<Rigidbody2D>().velocity = Vector3.down * 250 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 250 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            ball.GetComponent<Ball>().SlowDownBall();
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DeathWall"))
            Destroy(gameObject);
    }
}
