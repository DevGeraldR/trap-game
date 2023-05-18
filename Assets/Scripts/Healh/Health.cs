
using UnityEngine;

public class Health : MonoBehaviour
{
    // Use to set the starting health or the max health
    [SerializeField] private float startingHealth;
    // To play death sound when the player died
    [SerializeField] private AudioClip deathSound;
    // To keep track of the current health. This is singleton since current health was use in some other script to make it easily accessible
    public float currentHealth { get; private set; }
    // Use when playing animaiton
    private Animator anim;
    // Use to keep track if it is already game over
    public bool dead { get; private set; }

    // Runs when the component renders
    private void Awake()
    {
        dead = false;
        // To set the current health as the starting health
        currentHealth = startingHealth;
        // To ge the animator use in playing animation
        anim = GetComponent<Animator>();
    }

    // Function when the player got hit by the trap
    public void TakeDamage(float _damage)
    {
        // To check if not dead yet 
        if (!dead)
        {
            // If so then reduce life
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            // Play the die animation
            anim.SetTrigger("die");
            // To stop the playing from moving
            GetComponent<PlayerMoving>().enabled = false;
            // To set dead true
            dead = true;
            // To play the death sound
            SoundManager.instance.PlaySound(deathSound);
        }
    }

    // Use to respawn the playing
    public void Respawn()
    {
        // Stop the dead animation
        anim.ResetTrigger("die");
        // Play idle
        anim.Play("idle");
        // To make the playing move
        GetComponent<PlayerMoving>().enabled = true;
        // To set dead as false
        dead = false;
    }
}
