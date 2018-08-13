using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongLocation : MonoBehaviour
{
	public Transform startPosition;
	public Transform endPosition;
	public float moveSpeed = 1.0f;

	void Start()
	{
		transform.position = startPosition.position;
	}
		
	// Update is called once per frame
	private void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards(transform.position, endPosition.position,  moveSpeed );

		float distance = Vector2.Distance(transform.position, endPosition.position);

		if (Mathf.Approximately(distance, 0.0f))
		{
			Transform swapPosition = startPosition;

			startPosition = endPosition;
			endPosition = swapPosition;
		}
	}
}
