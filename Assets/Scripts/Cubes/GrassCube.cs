using UnityEngine;
using System.Collections;
using System;

public class GrassCube : CubeAbstract
{
	public GameObject Item;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		if (Item != null)
		{
			Debug.Log("Playe gather item");
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
