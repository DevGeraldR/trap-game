
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Use to display game over
    private UIManager uiManager;

    // Use to display game over
    private PlayerMoving playerMoving;

    // Use to get the players health
    private Health playerHealth;

    // Function to play when the component render
    private void Awake()
    {
        // To get the UI use in gave over
        uiManager = FindObjectOfType<UIManager>();

        // To get the UI use in gave over
        playerMoving = FindObjectOfType<PlayerMoving>();

        // To get the UI use in gave over
        playerHealth = FindObjectOfType<Health>();
    }

    // Use when the player bumps into the devider
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // If so then check if the one who bumps the finish is the user
        if (collision.tag == "Player" && !playerHealth.dead)
        {
            // To stop the playing from moving
            playerMoving.enabled = false;

            // If so then turn on the next level screen
            uiManager.FinishLevel();
        }
    }
}
