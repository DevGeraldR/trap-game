
using UnityEngine;

public class Trap_sideways : MonoBehaviour
{
    // Use to store the move distance of the trap when going sideways
    [SerializeField] private float movementDistance;
    // Use to store the speed of moving
    [SerializeField] private float speed;
    // Use to set the damage of the trap
    [SerializeField] private float damage;
    // use to track if the trap is moving left or right
    private bool movingLeft;
    // Use to set the range
    private float leftEdge;
    private float rightEdge;

    // Plays when the component renders
    private void Awake()
    {
        // To get the range
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // To update the game
    private void Update()
    {
        // Check if the trap is moving left
        if (movingLeft)
        {
            // if so then check if the trap already has not hit its range
            if (transform.position.x > leftEdge)
            {
                // if so keep the trap from moving left
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                // If not then it means that the trap is already in the range this set the moving left to false
                movingLeft = false;
        }
        else
        {
            // If the trap is not moving left then it means that it is moving right
            // Check if the trap is not already at its range
            if (transform.position.x < rightEdge)
            {
                // If so the keep the trap from moving left
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                // If not then it means that the trap is already in the range this set the moving left to true
                movingLeft = true;
        }
    }

    // Function when the player collided when the trap
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is the one who collided when the trap
        if(collision.tag == "Player")
        {
            // If so then reduce the life of the player
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
