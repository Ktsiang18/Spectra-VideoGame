using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Rigidbody2D[] enemies;                        // prefab object that we will draw for the bullet
	public float spawntime = 8.0f;
	private float waittime;
	public float timer;
	private int enemyCode = 1;

	private void Start()
	{
		StartCoroutine(Waittospawn());
	}
	void Update()
	{
		waittime = Random.Range(0, spawntime);
		timer += Time.deltaTime;
		if (timer > 75.0 && spawntime > 3.0)
		{
			spawntime = spawntime - 0.5f;
		}
		if ((10.0 < timer && timer < 20.0) || (35.0 < timer && timer < 45.0) || (65.0 < timer && timer < 75.0))
		{
			enemyCode = 0;
		}
		else if (20.0 < timer && timer < 35.0)
		{
			enemyCode = 3;
		}
		else
		{
			enemyCode = 6;
		}

	}

	IEnumerator Waittospawn()
	{
		yield return new WaitForSeconds(1);
		while (true)
		{

			Shoot();
			yield return new WaitForSeconds(waittime);

		}
	}

	void Shoot()
	{
		Rigidbody2D clone = Instantiate(enemies[Random.Range(0, enemyCode)], transform.position, transform.rotation) as Rigidbody2D;

	}
}