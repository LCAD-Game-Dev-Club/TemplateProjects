using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // This is a reference to the Game Manager in the scene
    public GameManager gameManagerScript;

    // When the player enters the collider for the Game Object this script is attached to...
    void OnTriggerEnter2D()
    {
        // ... Write a Debug message that tells us we've won...
        Debug.Log("You win!");
        // ... and set the Game Over Bool in the Game Manager to true
        gameManagerScript.gameOver = true;
    }
}
