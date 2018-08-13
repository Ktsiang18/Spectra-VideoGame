using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {


	public Rigidbody2D blueBulletPrefab;
	public Rigidbody2D redBulletPrefab;
	public Rigidbody2D yellowBulletPrefab;
	public AudioSource audio;
	public float velocity = 10.0f;

	public Animator animator;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Q))

		{
			ShootBlue ();
			audio.Play ();
			animator.SetBool("isShooting", true);

		}

		if (Input.GetKeyUp(KeyCode.Q))

		{

			animator.SetBool("isShooting", false);

		}

		if (Input.GetKeyDown(KeyCode.W))

		{
			ShootYellow ();
			audio.Play ();
			animator.SetBool("isShooting", true);
		}

		if (Input.GetKeyUp(KeyCode.W))

		{
			animator.SetBool("isShooting", false);
		}

		if (Input.GetKeyDown(KeyCode.E))

		{
			ShootRed ();
			audio.Play ();
			animator.SetBool("isShooting", true);
		}

		if (Input.GetKeyUp(KeyCode.E))

		{

			animator.SetBool("isShooting", false);
		}
	}

	void ShootBlue()
	{
		Rigidbody2D clone = Instantiate (blueBulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
		clone.velocity = transform.TransformDirection (transform.up * velocity);
	}

	void ShootRed()
	{
		Rigidbody2D clone = Instantiate (redBulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
		clone.velocity = transform.TransformDirection (transform.up * velocity);
	}

	void ShootYellow()
	{
		Rigidbody2D clone = Instantiate (yellowBulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
		clone.velocity = transform.TransformDirection (transform.up * velocity);
	}



}
