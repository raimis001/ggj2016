﻿using UnityEngine;
using System.Collections;
using System;

public class TreeCube : CubeAbstract
{
	public override bool CanMoveTo()
	{
		return false;
	}

	public override void OnPlayerLanded()
	{
		throw new NotImplementedException();
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
