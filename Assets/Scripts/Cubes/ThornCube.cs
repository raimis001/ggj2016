using UnityEngine;
using System.Collections;
using System;

public class ThornCube : CubeAbstract
{
	public int Value = -10;
	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		PlayerController.AddScore(Value);
		
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
