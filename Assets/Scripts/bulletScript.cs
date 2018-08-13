using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {


		public float thrust;
		public Rigidbody2D rb;

		void Start()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			rb.AddForce(transform.up * thrust);
		}

}
