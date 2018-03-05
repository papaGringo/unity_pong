using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketControl : MonoBehaviour {

	public float speed = 30f;
	public bool isAIEnabled = false;
	public string axis = "Vertical";

	private GameObject ball;
	void Update()
	{
		if(isAIEnabled)
		{
			ball = GameObject.FindGameObjectWithTag("ball");
		}
		else
		{
			ball = null;
		}

	}
	void FixedUpdate()
	{
		if(!isAIEnabled)
		{
			float v = Input.GetAxisRaw(axis);
			GetComponent<Rigidbody2D>().velocity = Vector2.up * v * speed;
		}
		else
		{	
			StartCoroutine("AIControl")	;
		}
	}
	IEnumerator AIControl()
	{
		while(ball)
		{
			if(ball.transform.position.normalized.x > 0.6f)
			{
				float d = ball.transform.position.y - transform.position.y;
				float f = d/ ball.GetComponent<BoxCollider2D>().bounds.size.y;				
				GetComponent<Rigidbody2D>().velocity = Vector2.up * speed  *  (d>0 ? 1.5f : -1.5f);
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
			yield return null;
		}
	}
}
