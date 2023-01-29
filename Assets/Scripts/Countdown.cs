using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{

    //other Variables
    private GameObject _inGameUI; //UI while playing
    private GameObject _gameOverUI; //UI while the Game is over

    //Countdown variables
    public float currentTime = 0f; 
    public float startingTime = 250f; //the time you get on the beginning of the game

    public float timeReduction = 20f; // the amount the time gets reduced every round 

    [SerializeField] Text _countdownUI; //the text of the Timer

    //Variables Round Counter
    private string _roundText = "Round: "; //the text of the round UI before the value 
    private Text _roundUI; // the text if the round Counter

    public int round = 0; //the round counter

    private Text _gameOverRoundUI; //the text of the round Counter, if the game is over

    //Variables Checkpoint Counter
    private Text _checkpointUI; //the text of the checkpoint Counter
    private string _checkpointText1 = "Checkpoint: "; //the beginning text message in front of the value of the Checkpoint counter
    private string _checkpointText2 = " of 10"; //the text at the end of the checkpoint Counter

    void Start()
    {
        //gest all components
        _inGameUI = GameObject.Find("InGame"); 
        _gameOverUI = GameObject.Find("GameOver"); 

        _roundUI = GameObject.Find("RoundScore").GetComponent<Text>();
        _gameOverRoundUI = GameObject.Find("Rounds").GetComponent<Text>();
        _checkpointUI = GameObject.Find("Checkpoint").GetComponent<Text>();
        _countdownUI = GameObject.Find("Timer").GetComponent<Text>();

        //sets the time
        currentTime = startingTime;
        round = -1; //round -1 because its counting up at the start point. Because its allways counting up if your reach the start point. Different way would be to set the next Checkpoint as next goal at the beginnig. But this needs less change
        
        //sets the UI / screen
        _inGameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }
   
    void Update()
    {
        //reduces the time by one second each second
        currentTime -= 1 * Time.deltaTime;
        _countdownUI.text = ("TIME: ") + currentTime.ToString ("0");

        if(currentTime <= 0) //if the time runs out 
        {
            currentTime = 0; //sets to zero, so we dont get negative numbers

            _gameOverRoundUI.text = _roundText + round; //writes the Text to the UI

            // sets the game of screen
            _inGameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }
    }

    public void newTimer() //resets the Timer with a reduced Time
    {
        //adds 1 to the round Counter and prints it to the screen
        round++; 
        _roundUI.text = _roundText + round.ToString();

        currentTime = startingTime - round * timeReduction; //redouces the time for the next Round
    }

    //sets a new Checkpoint
    public void newCheckpoint(int checkpointNumber) {
        _checkpointUI.text = _checkpointText1 + checkpointNumber.ToString() + _checkpointText2;
    }

}