using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
	//array of colored enemies to be spawned
	public Rigidbody2D[] enemies;                      
	public float spawntime = 10.0f;
	private float waittime;
	public float timer;
	private int enemyCode = 1;

	//initializes counter
	private void Start()
	{
		StartCoroutine(Waittospawn());
	}
	void Update() 
	{
		//randomly increases rate of enemy spawning
		waittime = Random.Range(0, spawntime);
		timer += Time.deltaTime;
		if (timer > 54.0 && spawntime > 5.0)
		{
			spawntime = spawntime - 0.5f;
		}
		//increases difficulty by increasing colors of enemies
		if ((10.0 < timer && timer < 13.0) || (28.0 < timer && timer < 31.0) || (51.0 < timer && timer < 54.0))
		{
			//1 color spawned
			enemyCode = 0;
		}
		if (13.0 < timer && timer < 28.0)
		{
			//4 colors spawned
			enemyCode = 3;
		}
		if (31.0 < timer)
		{
			//7 colors spawned
			enemyCode = 6;
		}

	}

	//carries out spawning
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
