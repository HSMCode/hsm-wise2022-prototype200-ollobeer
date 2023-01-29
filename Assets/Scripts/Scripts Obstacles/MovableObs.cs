using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObs : MonoBehaviour
{
	public float distance = 5f; //Distance that moves the object
	public bool horizontal = true; //If the movement is horizontal or vertical
	public float speed = 3f;
	public float offset = 0f; //If yo want to modify the position at the start 

	private bool _isForward = true; //If the movement is out
	private Vector3 _startPos;
   
    void Awake()
    {
		//modifying the position on awake
		_startPos = transform.position;
		if (horizontal)
			transform.position += Vector3.right * offset;
		else
			transform.position += Vector3.forward * offset;
	}

    // Update is called once per frame
    void Update()
    {
		if (horizontal) //horzontal movement
		{
			if (_isForward) //moving while moving forward
			{
				if (transform.position.x < _startPos.x + distance)
				{
					transform.position += Vector3.right * Time.deltaTime * speed;
				}
				else //switch to moving backwards
					_isForward = false;
			}
			else
			{
				if (transform.position.x > _startPos.x) //moving while moving backwards
				{
					transform.position -= Vector3.right * Time.deltaTime * speed;
				}
				else
					_isForward = true; //switch to moving backwards
			}
		}
		else
		{
			if (_isForward) //moving  while moving forwards
			{
				if (transform.position.z < _startPos.z + distance)
				{
					transform.position += Vector3.forward * Time.deltaTime * speed;
				}
				else
					_isForward = false; //switching to backwards
			}
			else //moving while moving backwards
			{
				if (transform.position.z > _startPos.z)
				{
					transform.position -= Vector3.forward * Time.deltaTime * speed;
				}
				else
					_isForward = true; //switching to forwards
			}
		}
    }
}
