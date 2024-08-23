using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
	[SerializeField] private float health = 5f;

	public void TakeDamage(float damage)
	{
		health -= damage;
		Debug.Log("Base health: " + health);
		if (health <= 0)
		{
			GameManager.instance.GameOver();
		}
	}
}
