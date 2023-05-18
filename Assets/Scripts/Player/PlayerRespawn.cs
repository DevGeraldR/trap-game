
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // Use to get the position of the current respawn point
    private Transform currentRespawnPoint;
    // Use to get the players health
    private Health playerHealth;
    // Use to display game over
    private UIManager uiManager;

    // Function to play when the component render
    private void Awake()
    {
        // To get the component health
        playerHealth = GetComponent<Health>();
        // To get the UI use in gave over
        uiManager = FindObjectOfType<UIManager>();
    }

    // To check whether it is game over or not
    public void CheckRespawn()
    {
        // To check if the player health reaches 0
        if(playerHealth.currentHealth == 0)
        {
            // If so then it is game over
            uiManager.GameOver();
            // To return and ignover all the function below
            return;
        }

        // If not means the player still has life
        // The respawn the player to the current respawn point
        transform.position = currentRespawnPoint.position;
        // This was created in Health script
        // Use to play the die animation and also idle
        // Then make the player move again and set dead to false
        playerHealth.Respawn();
    }

    // Use when the user got hit in the object in our case is the respawn point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // To check if the user bumps into the respawn point
        if(collision.tag == "RespawnPoint")
        {
            // if so then make the respawn point as the current respaw point
            currentRespawnPoint = collision.transform;
            // Then disable the collider to not play when the user bumps again since we already recorded it
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
    
}
