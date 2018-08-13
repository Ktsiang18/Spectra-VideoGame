using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpaceships : MonoBehaviour
{
	public Rigidbody2D[] enemies;                        // prefab object that we will draw for the bullet
	public float spawntime = 10.0f;
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
		if (timer > 54.0 && spawntime > 0.0)
		{
			spawntime = spawntime - 0.5f;
		}
		if ((10.0 < timer && timer < 13.0) || (28.0 < timer && timer < 31.0) || (51.0 < timer && timer < 54.0))
		{
			enemyCode = 0;
		}
		if (13.0 < timer && timer < 28.0)
		{
			enemyCode = 3;
		}
		if (31.0 < timer && timer < 51.0)
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