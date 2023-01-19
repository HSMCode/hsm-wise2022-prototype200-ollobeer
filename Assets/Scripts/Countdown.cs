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

    //Variables Checkpoint Counter
    private Text checkpointUI;
    private string checkpointText1 = "Checkpoint: ";
    private string checkpointText2 = " of 10";

    void Start()
    {
        _inGameUI = GameObject.Find("InGame");
        _gameOverUI = GameObject.Find("GameOver");

        roundUI = GameObject.Find("RoundScore").GetComponent<Text>();
        checkpointUI = GameObject.Find("Checkpoint").GetComponent<Text>();

        currentTime = startingTime;
        round = 0;

        _inGameUI.SetActive(true);
        _gameOverUI.SetActive(false);
    }
   
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = ("TIME: ") + currentTime.ToString ("0");

        if(currentTime <= 0) 
        {
            currentTime = 0;
        }
    }

    public void newTimer()
    {
        round++;
        roundUI.text = roundText + round.ToString();
        currentTime = startingTime - round * timeReduction;
    }

    public void newCheckpoint(int checkpointNumber) {
        checkpointUI.text = checkpointText1 + checkpointNumber.ToString() + checkpointText2;
    }

}