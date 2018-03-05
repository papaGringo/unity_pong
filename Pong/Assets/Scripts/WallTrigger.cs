using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "ball")
		{
			PongGameManager.Instance.DestroyBall();
			//PongGameManager.Instance.StartBall();
			StartCoroutine("Example");
		}	
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(2);
		PongGameManager.Instance.StartBall();
	}
}
