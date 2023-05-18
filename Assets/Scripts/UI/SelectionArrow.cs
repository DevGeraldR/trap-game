
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    // Use to store all the options
    [SerializeField] private RectTransform[] buttons;

    // Use to play sound when the user change an option or click an arrow up or down
    [SerializeField] private AudioClip changeSound;

    // Use to click when a user press enter or select an option
    [SerializeField] private AudioClip interactSound;

    // Use to control the selection arrow
    private RectTransform arrow;

    // Use to get the current position of our selection arrow
    private int currentPosition;

    // Play when the component was use
    private void Awake()
    {
        // Use to get the selection arrow component
        arrow = GetComponent<RectTransform>();
    }

    // When the selection arrow was on
    private void OnEnable()
    {
        currentPosition = 0;
        ChangePosition(0);
    }

    // Use to update the component 
    private void Update()
    {
        // Change the position of the selection arrow
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            ChangePosition(1);

        //Interact with current option
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    // Function to change the position of the selection arrow
    private void ChangePosition(int _change)
    {
        // to add the change to the current positon
        currentPosition += _change;

        // Use to play sound when to user change an option
       if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        // Use to not go outside the range of our options
        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;

        // To move the selection arrow to the disegnated area
        AssignPosition();
    }

    // Function move the selection arrow
    private void AssignPosition()
    {
        //Assign the Y position of the current option to the arrow (basically moving it up and down)
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }

    // Function when the user interact or press enter to a option
    private void Interact()
    {
        // To play the sound when the user press enter or selected an option
        SoundManager.instance.PlaySound(interactSound);

        //Access the button component on each option and call its function
        buttons[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
