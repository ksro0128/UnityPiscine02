using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private float spawnTime = 3f;
	[SerializeField] private GameObject[] waypoints;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spawnTime);
    }

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, transform.position, transform.rotation);
	}

	public GameObject[] GetWayPoints()
	{
		return waypoints;
	}

	public void StopSpawning()
	{
		CancelInvoke("SpawnEnemy");
	}
}
