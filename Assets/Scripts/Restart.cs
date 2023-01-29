using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button restartButton; 
    
    void Start()
    {
        restartButton.onClick.AddListener(RestartScene); //adds a on clock listner to the button
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts the current scene
    }
}
