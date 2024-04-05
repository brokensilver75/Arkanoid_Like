using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] int rows, cols;
    [SerializeField] float brickOffset;
    [SerializeField] float initialPosX, initialPosY;
    [SerializeField] GameObject brickPrefab;
    float currentX, currentY;
    int[,] levelLayout;

    void Awake()
    {
        currentX = initialPosX;
        currentY = initialPosY;

        levelLayout = new int[rows, cols];

        for (int i=0; i<rows; i++)
        {
            for (int j=0; j<cols; j++)
            {
                levelLayout[i,j] = UnityEngine.Random.Range(0,4);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<rows; i++)
        {
            for (int j=0; j<cols; j++)
            {
                var brick = Instantiate (brickPrefab.GetComponent<Brick>(), new Vector2(currentX, currentY), Quaternion.identity);
                
                currentX += (2 + brickOffset);
            }

            currentX = initialPosX;
            currentY -= brickOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}