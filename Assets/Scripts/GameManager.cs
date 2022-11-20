using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // A Game Manager is used to keep track of different information about the current state of the game!

    // This is a reference to the Character Controller Script on our Player
    public CharacterController2D characterControllerScript;

    // These are references to the UI Objects that we need to update
    public TextMeshProUGUI collectableCountText;
    public GameObject youWinUI;

    // This is the integer for how many collectables you have picked up
    public int collectableCount = 0;

    // This bool is whether or not the game has ended
    public bool gameOver = false;
    public bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        
        // If the Game Over bool in this script is true
        if (gameOver)
        {
            // ... Run the GameOver() function
            GameOver();
        }
        if (isDead)
        {
            Death();
        }
        // This updates the Collectable Count Text to match the Collectable Count Integer
        collectableCountText.text = collectableCount.ToString();
    }

    void GameOver()
    {
        // This runs the OnGameOver() function in the Character Controller Script...
        characterControllerScript.OnGameOver();
        // ... Then enables the Win Text
        youWinUI.SetActive(true);
    }
    void Death()
    {
        characterControllerScript.OnDeath();
    }
}
