using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // This is a reference to the Game Manager in the scene
    public GameManager gameManagerScript;

    // This is the Audio Source on our Collectable
    public AudioSource audioSource;
    public AudioClip collectSFX;

    // When the player enters the collider for the Game Object this script is attached to...
    void OnTriggerEnter2D()
    {
        // ... Write a Debug message that tells us what the current Collectable Count is...
        Debug.Log("Picked up! Current count is " + gameManagerScript.collectableCount);
        // ... Add 1 to the current Collectable Count Integer in the Game Manager...
        gameManagerScript.collectableCount++;
        // ... Play the Audio Clip...
        AudioSource.PlayClipAtPoint(collectSFX, transform.position);
        // ... And turn the Collectable object off
        this.gameObject.SetActive(false);
    }
}
