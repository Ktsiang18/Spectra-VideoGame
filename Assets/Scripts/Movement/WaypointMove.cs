using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove: MonoBehaviour
{


	public Transform[] waypoints;
	public int currentTargetIndex = 1;
	public float moveSpeed = 0.25f;

	private Transform endPosition;

	void Start()
	{
		endPosition = new GameObject().transform;
		// make sure there are waypoints
		//
		if (waypoints.Length > 0)
		{
			Debug.Log( waypoints.Length );
			Debug.Log(waypoints[0].position);
			Debug.Log(waypoints[1].position);
			
			// start at the first waypoint
			//
			transform.position = waypoints[0].position;

			endPosition.position = waypoints[1].position;
		}

	}
		
	// Update is called once per frame
	private void FixedUpdate()
	{
		// move towards the next waypoint on the list
		transform.position = Vector2.MoveTowards(transform.position, endPosition.position,  moveSpeed );

		float distance = Vector2.Distance(transform.position, endPosition.position);

		if (Mathf.Approximately(distance, 0.0f))
		{
			// we have arrived, get the index of the next waypoint on the list
			//
			currentTargetIndex++;
			
			// if there are no more waypoints, go back to the start
			//
			if (currentTargetIndex >= waypoints.Length)
			{
				currentTargetIndex = 0;
			}

			// set the end position to the next waypoint on the list
			//
			endPosition.position = waypoints[currentTargetIndex].position;

		}
	}
}
