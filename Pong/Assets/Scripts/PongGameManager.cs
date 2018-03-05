using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGameManager : MonoBehaviour 
{
	private static PongGameManager _instance;
	public static PongGameManager Instance
	{
		get{return _instance;}
	}

	void Awake()
	{
		if(_instance != null && _instance == this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	void Start()
	{
		StartBall();
	}

	public GameObject ballPrefab;

	private GameObject currBall;
	public GameObject[] spawnPoints;

	public void StartBall()
	{
		int i = Random.Range(0, spawnPoints.Length);
		currBall = Instantiate(ballPrefab, spawnPoints[i].transform);
		
		currBall.transform.SetParent(this.gameObject.transform);
	}

	public void DestroyBall()
	{
		currBall.transform.SetParent(null);
		Destroy(currBall, 2);
	}
}
