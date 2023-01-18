using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{

    public GameObject Ball;

    //Check for Trigger by gameObject Ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Checkpoint reached!");
        }
    }
}
