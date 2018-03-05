using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "ball")
		{
			PongGameManager.Instance.UpdateScoreAndDrawBallAgain(this.gameObject.tag);			
		}	
	}
}
