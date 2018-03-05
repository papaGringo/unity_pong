using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "ball")
		{
			PongGameManager.Instance.DestroyBall();			
			PongGameManager.Instance.UpdateScore(this.gameObject.tag);
			StartCoroutine("RestartBall");
		}	
	}

	IEnumerator RestartBall()
	{
		yield return new WaitForSeconds(2);
		PongGameManager.Instance.StartBall();
	}
}
