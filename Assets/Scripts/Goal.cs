using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // This is a reference to the Game Manager in the scene
    public GameManager gameManagerScript;

    // This is the Audio Source and Audio Clip on our Goal
    public AudioSource audioSource;
    public AudioClip goalSFX;

    // When the player enters the collider for the Game Object this script is attached to...
    void OnTriggerEnter2D()
    {
        // ... Write a Debug message that tells us we've won...
        Debug.Log("yummy burger");
        // ... Play the Audio Clip at the place where the Goal is...
        AudioSource.PlayClipAtPoint(goalSFX, transform.position);
        // ... and set the Game Over Bool in the Game Manager to true
        gameManagerScript.gameOver = true;
    }
}
