using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    
    public void Play()
    {
        gameManager.GetComponent<GameManager>().LoadLevel();
    }
}
