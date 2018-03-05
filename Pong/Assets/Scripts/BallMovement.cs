using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float speed = 30f;

	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}
}
