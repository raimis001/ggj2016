using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

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
	protected override void Start()
	{
		base.Start();
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if ((Right == null || Right is LavaCube) && (Left == null || Left is LavaCube))
		{
			return;
		}
		burnTime -= Time.fixedDeltaTime;
		if (burnTime > 0)
		{
			return;
		}
		if (Random.value > 0.5f && Right != null && !(Right is LavaCube))
		{
			Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), Right);
			burnTime = 2;
			return;
		}
		if (Left != null && !(Left is LavaCube))
		{
			Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), Left);
			burnTime = 2;
			return;
		}
	}
}
