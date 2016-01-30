using UnityEngine;
using System.Collections;
using System;

public class SwampCube : CubeAbstract
{
	public float StuckTime = 2f;

	public override bool CanMoveTo()
	{
		return true;
	}


	public override void OnPlayerLanded()
	{
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
