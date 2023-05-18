
using UnityEngine;

public class Trap_Upwards: MonoBehaviour
{
    // Use to store the move distance of the trap when going sideways
    [SerializeField] private float movementDistance;
    // Use to store the speed of moving
    [SerializeField] private float speed;
    // Use to set the damage of the trap
    [SerializeField] private float damage;
    // use to track if the trap is moving top or bottom
    private bool movingTop;
    // Use to set the range
    private float topEdge;
    private float bottomEdge;

    // Plays when the component renders
    private void Awake()
    {
        // To get the range
        topEdge = transform.position.y - movementDistance;
        bottomEdge = transform.position.y + movementDistance;
    }

    // To update the game
    private void Update()
    {
        // Check if the trap is moving top
        if (movingTop)
        {
            // if so then check if the trap already has not hit its range
            if (transform.position.y > topEdge)
            {
                // if so keep the trap from moving top
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                // If not then it means that the trap is already in the range this set the moving top to false
                movingTop = false;
        }
        else
        {
            // If the trap is not moving top then it means that it is moving bottom
            // Check if the trap is not already at its range
            if (transform.position.y < bottomEdge)
            {
                // If so the keep the trap from moving top
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                // If not then it means that the trap is already in the range this set the moving top to true
                movingTop = true;
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
