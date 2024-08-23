using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void GameOver()
	{
		Debug.Log("Game Over!");
		
		foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
		{
			spawner.StopSpawning();
		}
		foreach (EnemyController enemy in FindObjectsOfType<EnemyController>())
		{
			Destroy(enemy.gameObject);
		}
	}
}
