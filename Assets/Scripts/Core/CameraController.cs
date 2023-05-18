
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // To get the speed of the movement of the camera
    [SerializeField] private float speed;
    // To store the current position of x axis of the camera
    private float currentPosX;
    // Use to reference
    private Vector3 velocity = Vector3.zero;
    
    // Function that update the camera position
    private void Update()
    {
        // To move the camera to the specified location
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    // Function to record the next room positon
    public void MoveToNewRoom(Transform _newRoom)
    {
        // To get the next roow
        currentPosX = _newRoom.position.x;
    }
}
