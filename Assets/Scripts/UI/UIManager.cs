
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Use to make gave over screen appear
    [SerializeField] private GameObject gameOverScreen;

    // Use to play gave over sound
    [SerializeField] private AudioClip gameOverSound;

    // Use to make next level screen appear
    [SerializeField] private GameObject nextLevelScreen;

    // Use to play gnext level sound
    [SerializeField] private AudioClip winSound;

    // Use to pause the screen
    [SerializeField] private GameObject pauseScreen;

    // Use to instruction the screen
    [SerializeField] private GameObject instructionsScreen;

    // Use in menu the screen
    [SerializeField] private GameObject menuScreen;

    // To check wether the player click esc button
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause and viceversa
            PauseGame(!pauseScreen.activeInHierarchy);
        } 
    }

    //Start level
    // This is use in MAIN MENU
    public void StartGame()
    {
        // To move the scene to level
        SceneManager.LoadScene(1);
    }

    //Instructions function
    public void Instructions()
    {

        // To make the instructions screen appear
        instructionsScreen.SetActive(true);
        // To hide the menu screen
        menuScreen.SetActive(false);
    }

    //Hide Instructions function
    public void Back()
    {
        // To make the instructions screen appear
        instructionsScreen.SetActive(false);
        // To show the menu screen
        menuScreen.SetActive(true);
    }

    //Game over function
    public void GameOver()
    {
        // To make the gave over screen appear
        gameOverScreen.SetActive(true);
        // To play the gave over sound
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Next Level function
    public void FinishLevel()
    {

        // To make the gave over screen appear
        nextLevelScreen.SetActive(true);

        // To play the gave over sound
        SoundManager.instance.PlaySound(winSound);
    }

    // Function to pause the screen
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    //Next Level function
    public void NextLevel()
    {
        // To move the scene to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Restart level
    public void Restart()
    {
        // To move the scene to the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Activate Main menu
    public void MainMenu()
    {
        // To unpause the game in case the game is pause
        PauseGame(false);
        // To move to the main menu scene
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        //Quits the game (only works in build)
        Application.Quit(); 
    }
}
