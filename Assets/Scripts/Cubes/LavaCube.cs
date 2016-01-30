using UnityEngine;
using System.Collections;
using System;

public class LavaCube : CubeAbstract
{

	float burnTime = 2;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		PlayerControler.Instance.BurnGirl();
	}

	// Use this for initialization
	void Start()
	{
		if ((Right == null || Right is LavaCube) && (Left == null || Left is LavaCube))
		{
			return;
		}

		burnTime -= Time.deltaTime;
		if (burnTime > 0)
		{
			return;
		}

		if (Right != null && !(Right is LavaCube))
		{
			//TOOO sadedzināt cubu
			burnTime = 2;
      return;
		}
		if (Left != null && !(Left is LavaCube))
		{
			//TOOO sadedzināt cubu
			burnTime = 2;
			return;
		}

	}

	// Update is called once per frame
	void Update()
	{

	}
}
