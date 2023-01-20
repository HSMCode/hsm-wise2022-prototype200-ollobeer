using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{

    //other Variables
    private GameObject _inGameUI;
    private GameObject _gameOverUI;

    //Countdown variables
    public float currentTime = 0f;
    public float startingTime = 250f;

    public float timeReduction = 20f;

    [SerializeField] Text countdownText;

    //Variables Round Counter
    private string roundText = "Round: ";
    private Text roundUI;

    public int round = 0;

    private Text gameOverRoundUI;

    //Variables Checkpoint Counter
    private Text checkpointUI;
    private string checkpointText1 = "Checkpoint: ";
    private string checkpointText2 = " of 10";

    void Start()
    {
        //gest all components
        _inGameUI = GameObject.Find("InGame");
        _gameOverUI = GameObject.Find("GameOver");

        roundUI = GameObject.Find("RoundScore").GetComponent<Text>();
        gameOverRoundUI = GameObject.Find("Rounds").GetComponent<Text>();
        checkpointUI = GameObject.Find("Checkpoint").GetComponent<Text>();

        //sets the time
        currentTime = startingTime;
        round = -1;
        
        //sets the screen
        _inGameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }
   
    void Update()
    {
        //reduces the time by one second each second
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = ("TIME: ") + currentTime.ToString ("0");

        if(currentTime <= 0) //if the time runs out 
        {
            currentTime = 0;

            gameOverRoundUI.text = roundText + round;

            // sets the game of screen
            _inGameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }
    }

    public void newTimer() //resets the Timer with a reduced Time
    {
        round++;
        roundUI.text = roundText + round.ToString();
        currentTime = startingTime - round * timeReduction;
    }

    //sets a new Checkpoint
    public void newCheckpoint(int checkpointNumber) {
        checkpointUI.text = checkpointText1 + checkpointNumber.ToString() + checkpointText2;
    }

}