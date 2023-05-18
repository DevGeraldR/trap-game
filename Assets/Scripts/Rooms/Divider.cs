// This is use when the user change room to change the camera position

using UnityEngine;

public class Divider : MonoBehaviour
{
    // To get the next room location
    [SerializeField] private Transform nextRoom;

    // To get the camera controller script
    [SerializeField] private CameraController cam;

    // Use to get the players health
    private Health playerHealth;

    // Function to play when the component render
    private void Awake()
    {
        // To get the UI use in gave over
        playerHealth = FindObjectOfType<Health>();
    }

    // To keep track when the player already passed the devider
    private bool passed;

    // Use when the player bumps into the devider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // To check if the user has not passed yet
        if(!passed)
            // If so then check if the one who bumps the devider is the user
            if(collision.tag == "Player" && !playerHealth.dead)
            { 
                // To update the passed to true
                passed = true;

                // To mvoe the camera to the next room
                cam.MoveToNewRoom(nextRoom);
            }
    }
}
