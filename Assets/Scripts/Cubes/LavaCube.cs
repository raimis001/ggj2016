using UnityEngine;
using System.Collections;
using System;

public class LavaCube : CubeAbstract
{
	public override bool CanMoveTo()
	{
		return false;
	}

	public override void OnPlayerLanded()
	{
		PlayerControler.Instance.BurnGirl();
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
