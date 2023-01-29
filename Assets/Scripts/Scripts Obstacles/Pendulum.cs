using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	public float speed = 1.5f;
	public float limit = 75f; //Limit in degrees of the movement
	public bool randomStart = false; //If you want to modify the start position
	private float _random = 0;

	// Start is called before the first frame update
	void Awake()
    {
		//for a random start
		if(randomStart)
			_random = Random.Range(0f, 1f);
	}

    // Update is called once per frame
    void Update()
    {
		//moving the pendulum
		float angle = limit * Mathf.Sin(Time.time + _random * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
