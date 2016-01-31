using UnityEngine;
using System.Collections;
using System;

public class StoneCube : CubeAbstract
{
	public override bool CanMoveTo()
	{
		PlayerController.Instance.PlaySound(2);
		return false;
	}

	public override void OnPlayerLanded()
	{
		PlayerController.Instance.BurnGirl();
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
