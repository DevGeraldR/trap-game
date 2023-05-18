
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    // Use to get the player healt component
    [SerializeField] private Health playerHealth;

    // Use to show the total healthbar this is use to display the black heart when the user died
    [SerializeField] private Image totalHealthBar;

    // Use for displaying the current healt
    [SerializeField] private Image currentHealthBar;

    // When the game start
    private void Start()
    {
        // Use to display the full health at the begining
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        // Use to display the new health
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
