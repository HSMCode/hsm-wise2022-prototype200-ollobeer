using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{

    private int _nextGoal; //Number of the next Goal

    private bool _onTheWayBack; //is he on the way back?

    private Countdown _countdown; //script to update Checkpoints on UI

    private int _checkpointNumber;

    // Start is called before the first frame update
    void Start()
    {
        _countdown = GameObject.Find("Canvas").GetComponent<Countdown>(); //finds GoalManager Script
        _onTheWayBack = false; //at the beginning the player isnt on the way back
        _checkpointNumber = 0; //sets the checkpoint to zero
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks of the right checkpoint is reached and deals with some cases
    public void checkGoal(int goalNumber)
    {
        if(goalNumber == _nextGoal) //if the right checkpoint is reached
        {
            if(_nextGoal == 5) //if the end of the parkour is reached 
            {
                _nextGoal--; //next goal is behind
                _onTheWayBack = true; //now on the way back

                _checkpointNumber++;
                _countdown.newCheckpoint(_checkpointNumber);

            }else if (_nextGoal == 0) //if the beginning of the parkour is reached
            {
                _nextGoal++;
                _onTheWayBack = false; //not anymore on the way back

                _checkpointNumber = 0; //resets Checkpoints
                _countdown.newCheckpoint(_checkpointNumber);

                _countdown.newTimer(); // new timer with reduced time

            }else if (!_onTheWayBack) //if the player isnt on the way back
            {
                _nextGoal++;

                _checkpointNumber++;
                _countdown.newCheckpoint(_checkpointNumber);

            }else if (_onTheWayBack) // if the player is on the way back
            {
                _nextGoal--;
                
                _checkpointNumber++;
                _countdown.newCheckpoint(_checkpointNumber);
            }
        }else //if the wrong checkpoint is reached
        {
            Debug.Log("Wrong Checkpoint!");
        }
    }
}
