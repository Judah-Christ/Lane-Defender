using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerInput playerInput; // the player input 
    private InputAction restart; // the action needed to restart game
    private InputAction quit; // the action input for quiting the game 

    public TMP_Text scoreText;
    public int score = 0;  // starting the score at 0
    public TMP_Text endGameText;
   

    public TMP_Text livesText;
    private int lives = 3;  // starting the lives at 3 for the player
    public TMP_Text restartText;
    public TMP_Text quitText;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.currentActionMap.Enable();
        restart = playerInput.currentActionMap.FindAction("RestartGame");
        quit = playerInput.currentActionMap.FindAction("QuitGame");

        restart.started += Restart_started;

        quit.started += Quit_started;

        endGameText.gameObject.SetActive(false);

        //adds the words to the screen while turning the int into a string
        livesText.text = "Lives:" + lives.ToString();
        scoreText.text = "Score:" + score.ToString();
        restartText.gameObject.SetActive(false);
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }


    public void updateScore()  // updates the score on the screen while displaying you win when the score is over 4000 and resetting the ball.
    {
        score += 100;
        scoreText.text = "Score:" + score.ToString();

        if (score >= 4000)
        {
            endGameText.text = "YOU WIN!!";
            endGameText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);

        }
    }

    public void LoseALife()  // lives are displayed on the screen and when lives are at 0 then the words you have failed will pop up on the screen 
    {
        lives--;
        livesText.text = "Lives:" + lives.ToString();
        if (lives == 0)
        {
            endGameText.text = "YOU HAVE FAILED";
            endGameText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
