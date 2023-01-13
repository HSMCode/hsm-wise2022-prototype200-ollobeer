using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject _player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    
    void LateUpdate()
    {
        transform.position = _player.transform.position + offset;    
    }
}
