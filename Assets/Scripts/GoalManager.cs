using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{

    private int nextGoal; //Number of the next Goal

    private bool onTheWayBack; //is he on the way back?

    private Countdown countdown;

    private int checkpointNumber;

    // Start is called before the first frame update
    void Start()
    {
        countdown = GameObject.Find("Canvas").GetComponent<Countdown>(); //finds GoalManager Script
        onTheWayBack = false;
        checkpointNumber = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkGoal(int goalNumber)
    {
        if(goalNumber == nextGoal)
        {
            if(nextGoal == 5)
            {
                nextGoal--;
                onTheWayBack = true;

                checkpointNumber++;
                countdown.newCheckpoint(checkpointNumber);

            }else if (nextGoal == 0)
            {
                nextGoal++;
                onTheWayBack = false;

                checkpointNumber = 0;
                countdown.newCheckpoint(checkpointNumber);

                countdown.newTimer();
            }else if (!onTheWayBack)
            {
                nextGoal++;

                checkpointNumber++;
                countdown.newCheckpoint(checkpointNumber);

            }else if (onTheWayBack)
            {
                nextGoal--;
                
                checkpointNumber++;
                countdown.newCheckpoint(checkpointNumber);
            }
        }else 
        {
            Debug.Log("Wrong Checkpoint!");
        }
    }
}
