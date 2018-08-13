using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttributeBar : MonoBehaviour
{

	private int _attributeValue = 0;

	public delegate void OnHealthChange(int health);

	public static event OnHealthChange onHealthChange;
	
	public int PlayerAttribute
	{
		get { return _attributeValue; }
		set
		{
			if (_attributeValue == value) {return;}

			_attributeValue = value;
			if (onHealthChange != null)
			{
				onHealthChange(_attributeValue);
			}
		}
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
