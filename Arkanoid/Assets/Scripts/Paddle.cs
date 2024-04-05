using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
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
}
