using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private float health = 3f;
	[SerializeField] private float damage = 1f;

	private GameObject[] waypoints;
	private int currentWaypointTarget = 0;

    void Start()
    {
        currentWaypointTarget = 0;
		waypoints = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().GetWayPoints();
    }

    void Update()
    {
		if (Vector3.Distance(transform.position, waypoints[currentWaypointTarget].transform.position) < 0.1f)
		{
			currentWaypointTarget++;
			if (currentWaypointTarget >= waypoints.Length)
			{
				Destroy(gameObject);
			}
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointTarget].transform.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Base")
		{
			other.gameObject.GetComponent<BaseManager>().TakeDamage(damage);
			Destroy(gameObject);
		}
    }

	public float GetDamage()
	{
		return damage;
	}

	public float GetSpeed()
	{
		return speed;
	}

	public Vector3 GetCurrentWaypointPosition()
	{
		return waypoints[currentWaypointTarget].transform.position;
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

}
