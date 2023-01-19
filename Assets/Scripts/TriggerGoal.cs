using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{

    public GameObject Ball;

    private int thisGoal; //Number of the Goal

    private GoalManager goalManager; //GoalManager Script

    void Start() 
    {
        goalManager = GameObject.Find("GoalManager").GetComponent<GoalManager>(); //finds GoalManager Script
    }

    void Update() 
    {
        
    }

    //Check for Trigger by gameObject Ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Checkpoint reached!");

            //gets the Number of the Goal
            if (this.gameObject.CompareTag("GoalStart"))
            {
                thisGoal = 0;
            }else if (this.gameObject.CompareTag("Goal1"))
            {
                thisGoal = 1;
            }else if (this.gameObject.CompareTag("Goal2"))
            {
                thisGoal = 2;
            }else if (this.gameObject.CompareTag("Goal3"))
            {  
                thisGoal = 3;
            }else if (this.gameObject.CompareTag("Goal4"))
            {
                thisGoal = 4;
            }else if (this.gameObject.CompareTag("Goal5"))
            {
                thisGoal = 5;
            }

            goalManager.checkGoal(thisGoal); //sends the goalNumber to the GoalManager
        }
    }
}
