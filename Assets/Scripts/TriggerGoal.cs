using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{

    public GameObject Ball;

    private int _thisGoal; //Number of the Goal

    private GoalManager _goalManager; //GoalManager Script

    void Start() 
    {
        _goalManager = GameObject.Find("GoalManager").GetComponent<GoalManager>(); //finds GoalManager Script
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
                _thisGoal = 0;
            }else if (this.gameObject.CompareTag("Goal1"))
            {
                _thisGoal = 1;
            }else if (this.gameObject.CompareTag("Goal2"))
            {
                _thisGoal = 2;
            }else if (this.gameObject.CompareTag("Goal3"))
            {  
                _thisGoal = 3;
            }else if (this.gameObject.CompareTag("Goal4"))
            {
                _thisGoal = 4;
            }else if (this.gameObject.CompareTag("Goal5"))
            {
                _thisGoal = 5;
            }

            _goalManager.checkGoal(_thisGoal); //sends the goalNumber to the GoalManager
        }
    }
}
