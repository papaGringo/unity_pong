using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		scoreManager = new ScoreManager();
		scoreManager.ResetScores();
	}

	public GameObject ballPrefab;

	private GameObject currBall;
	public GameObject[] spawnPoints;

	public ScoreManager scoreManager;

	private void StartBall()
	{
		int i = Random.Range(0, spawnPoints.Length);
		currBall = Instantiate(ballPrefab, spawnPoints[i].transform);
		currBall.transform.SetParent(this.gameObject.transform);
	}

	private void DestroyBall()
	{
		currBall.transform.SetParent(null);
		Destroy(currBall, 2);
	}

	private void UpdateScore(string wallName)
	{
		if(wallName == "scoreWallLeft")
		{
			scoreManager.ScoreUpdatePlayer2();
		}
		else if( wallName == "scoreWallRight")
		{
			scoreManager.ScoreUpdatePlayer1();
		}
		scoreTxt1.text = scoreManager.score1.ToString();
		scoreTxt2.text = scoreManager.score2.ToString();
	}

	[System.Serializable]
	public class ScoreManager
	{
		public int score1 = 0;
		public int score2 = 0;

		public void ResetScores()
		{
			score1 = 0; score2 = 0;
		}

		public void ScoreUpdatePlayer1()
		{
			score1++;
		}

		public void ScoreUpdatePlayer2()
		{
			score2++;
		}

		public string DisplayScore
		{
			get
			{
				return string.Format("Player1 {0} - {1} Player2", score1, score2);
			}
		}
	}

	public Text scoreTxt1;
	public Text scoreTxt2;

	public void UpdateScoreAndDrawBallAgain(string wallName)
	{
		DestroyBall();
		UpdateScore(wallName);
		StartCoroutine(RestartBall());
	}

	IEnumerator RestartBall()
	{
		yield return new WaitForSeconds(2);
		StartBall();
	}
	
	
}
