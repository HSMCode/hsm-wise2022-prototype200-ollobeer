using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject _player;
    public Vector3 offset; //to get behind the player

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player"); //finds the Game Object with the Player Tag
    }
    
    void LateUpdate()
    {
        transform.position = _player.transform.position + offset;    //to follow the Player with an offset
    }
}
