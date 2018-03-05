using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketControl : MonoBehaviour {

	public float speed = 30f;
	public string axis = "Vertical";
	void FixedUpdate()
	{
		float v = Input.GetAxisRaw(axis);
		GetComponent<Rigidbody2D>().velocity = Vector2.up * v * speed;
	}
}
