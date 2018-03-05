using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float speed = 30f;

	void Start()
	{
		float xDir = (Random.Range(0,2) * 2) - 1;
		float yDir = Random.Range(-1.0f, 1.0f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(xDir, yDir) * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "racket")
		{
			float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
			Vector2 direction = new Vector2(collision.gameObject.name == "RacketHolderLeft"? 1: -1 , y).normalized;

			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
	{
		//1 top of racket ; 0 middle of racket; -1 bottom of racket
		return (ballPos.y - racketPos.y)/ racketHeight;
	}
}
