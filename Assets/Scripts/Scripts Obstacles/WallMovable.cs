using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovable : MonoBehaviour
{
	public bool isDown = true; //If the wall starts down, if not you must modify to false
	public bool isRandom = true; //If you want that the wall go down random
	public float speed = 2f;

	private float _height; //Height of the platform
	private float _posYDown; //Start position of the Y coord
	private bool _isWaiting = false; //If the wall is waiting up or down
	private bool _canChange = true; //If the wall is thinking if should go down or not

	void Awake()
    {
		_height = transform.localScale.y;
		if(isDown)
			_posYDown = transform.position.y;
		else
			_posYDown = transform.position.y - _height;
	}

    // Update is called once per frame
    void Update()
    {
		if (isDown)
		{
			if (transform.position.y < _posYDown + _height)
			{
				transform.position += Vector3.up * Time.deltaTime * speed;
			}
			else if (!_isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
		else
		{
			if (!_canChange)
				return;

			if (transform.position.y > _posYDown)
			{
				transform.position -= Vector3.up * Time.deltaTime * speed;
			}
			else if (!_isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
	}

	//Function that wait before go down or up
	IEnumerator WaitToChange(float time)
	{
		_isWaiting = true;
		yield return new WaitForSeconds(time);
		_isWaiting = false;
		isDown = !isDown;

		if (isRandom && !isDown) //If is wall up and is random
		{
			int num = Random.Range(0, 2);
			//Debug.Log(num);
			if (num == 1)
				StartCoroutine(Retry(1.5f));
		}
	}

	//Function that checks every 1.25secs if can go down the wall
	IEnumerator Retry(float time)
	{
		_canChange = false;
		yield return new WaitForSeconds(time);
		int num = Random.Range(0, 2);

		if (num == 1)
			StartCoroutine(Retry(1.25f));
		else
			_canChange = true;
	}
}
