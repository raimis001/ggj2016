using UnityEngine;
using System.Collections;
using System;

public class StoneCube : CubeAbstract
{
	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
	}

	// Use this for initialization
	override protected void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
